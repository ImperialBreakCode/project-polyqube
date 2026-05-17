'use client';

import type { ChatHistoryMessageApiModel } from '../types';
import {
	buildMappedMessages,
	getPrimaryParticipant,
	mapMessageParticipants,
	mergeChatHistoryMessages,
} from '../utils';
import { getSignalRAccessToken, type MessageResponseDTO } from '@/server';
import {
	useChatParticipants,
	useCurrentProfile,
	useMessageHistory,
} from '@/shared';
import {
	HubConnection,
	HubConnectionBuilder,
	HubConnectionState,
	HttpTransportType,
} from '@microsoft/signalr';
import {
	useCallback,
	useEffect,
	useMemo,
	useRef,
	useState,
	startTransition,
} from 'react';

export type ChatSendOptions = {
	requestAgentReply?: boolean;
};

/** Same-origin path; `next.config` rewrites `/api/*` to `API_BASE_HOST`. Must match Chats API `MapHub` path. */
const CHAT_HUB_PATH = '/api/v1/chat/hubs/chat';

function dtoToHistoryMessage(
	dto: MessageResponseDTO,
): ChatHistoryMessageApiModel {
	return {
		id: dto.id,
		textContent: dto.textContent,
		messageType: dto.messageType,
		participantId: dto.participantId,
		chatId: dto.chatId,
		createdAt: dto.createdAt,
	};
}

export function useChatRoom(chatId: string | undefined) {
	const { currentProfile } = useCurrentProfile();
	const { participants, getChatParticipants } = useChatParticipants();
	const { messages: historyMessages, getMessageHistory } =
		useMessageHistory();

	const [chatDataReady, setChatDataReady] = useState(false);
	const [liveMessages, setLiveMessages] = useState<
		ChatHistoryMessageApiModel[]
	>([]);
	const [hubReady, setHubReady] = useState(false);
	const [peerIsTyping, setPeerIsTyping] = useState(false);
	const hubRef = useRef<HubConnection | null>(null);
	const typingHideTimeoutRef = useRef<ReturnType<typeof setTimeout> | null>(
		null,
	);
	const lastTypingNotifyRef = useRef(0);

	const messageParticipants = useMemo(
		() => mapMessageParticipants(participants),
		[participants],
	);

	const firstParticipant = useMemo(
		() => getPrimaryParticipant(messageParticipants, currentProfile?.id),
		[currentProfile?.id, messageParticipants],
	);

	const mappedMessages = useMemo(() => {
		const merged = mergeChatHistoryMessages(historyMessages, liveMessages);
		return buildMappedMessages({
			historyMessages: merged,
			participants: messageParticipants,
			currentProfileId: currentProfile?.id,
		});
	}, [
		currentProfile?.id,
		historyMessages,
		liveMessages,
		messageParticipants,
	]);

	useEffect(() => {
		if (!chatId) {
			startTransition(() => {
				setChatDataReady(false);
				setLiveMessages([]);
			});
			return;
		}

		let cancelled = false;
		startTransition(() => {
			setChatDataReady(false);
			setLiveMessages([]);
		});

		void (async () => {
			await Promise.all([
				getChatParticipants(chatId, { includeAgents: true }),
				getMessageHistory({ chatId, count: 100, offset: 0 }),
			]);
			if (!cancelled) {
				setChatDataReady(true);
			}
		})();

		return () => {
			cancelled = true;
		};
	}, [chatId, getChatParticipants, getMessageHistory]);

	useEffect(() => {
		if (!chatId || !chatDataReady || !currentProfile?.id) {
			startTransition(() => {
				setHubReady(false);
				setPeerIsTyping(false);
			});
			return;
		}

		let cancelled = false;
		const activeChatId = chatId;
		let connection: HubConnection | null = null;

		void (async () => {
			const { token } = await getSignalRAccessToken();
			const hubUrl = CHAT_HUB_PATH;

			if (cancelled || !token) {
				return;
			}

			connection = new HubConnectionBuilder()
				.withUrl(hubUrl, {
					accessTokenFactory: () => token,
					transport:
						HttpTransportType.WebSockets |
						HttpTransportType.ServerSentEvents |
						HttpTransportType.LongPolling,
				})
				.withAutomaticReconnect()
				.build();

			connection.onreconnected(() => {
				void connection!.invoke('JoinChat', activeChatId);
			});

			connection.on('MessageReceived', (dto: MessageResponseDTO) => {
				if (dto.chatId !== activeChatId) {
					return;
				}
				const incoming = dtoToHistoryMessage(dto);
				setLiveMessages((previous) =>
					previous.some((m) => m.id === incoming.id)
						? previous
						: [...previous, incoming],
				);
			});

			connection.on('UserTyping', () => {
				setPeerIsTyping(true);
				if (typingHideTimeoutRef.current) {
					clearTimeout(typingHideTimeoutRef.current);
				}
				typingHideTimeoutRef.current = setTimeout(() => {
					typingHideTimeoutRef.current = null;
					setPeerIsTyping(false);
				}, 2500);
			});

			if (cancelled) {
				await connection.stop();
				return;
			}

			try {
				await connection.start();
				if (cancelled) {
					await connection.stop();
					return;
				}
				await connection.invoke('JoinChat', activeChatId);
				hubRef.current = connection;
				setHubReady(connection.state === HubConnectionState.Connected);
			} catch (error) {
				console.error('SignalR connection failed', error);
				setHubReady(false);
				await connection.stop();
			}
		})();

		return () => {
			cancelled = true;
			if (typingHideTimeoutRef.current) {
				clearTimeout(typingHideTimeoutRef.current);
				typingHideTimeoutRef.current = null;
			}
			startTransition(() => {
				setHubReady(false);
				setPeerIsTyping(false);
			});
			hubRef.current = null;
			const activeConnection = connection;
			if (!activeConnection) {
				return;
			}
			activeConnection.off('MessageReceived');
			activeConnection.off('UserTyping');
			void (async () => {
				try {
					if (
						activeConnection.state === HubConnectionState.Connected
					) {
						await activeConnection.invoke(
							'LeaveChat',
							activeChatId,
						);
					}
				} catch {}
				await activeConnection.stop();
			})();
		};
	}, [chatId, chatDataReady, currentProfile?.id]);

	const sendMessage = useCallback(
		async (text: string, options?: ChatSendOptions) => {
			if (!chatId) {
				return;
			}
			const hub = hubRef.current;
			if (!hub || hub.state !== HubConnectionState.Connected) {
				return;
			}
			await hub.invoke('SendChatMessage', chatId, text);
			if (options?.requestAgentReply) {
				try {
					await hub.invoke<MessageResponseDTO>(
						'PromptChatAgent',
						chatId,
						text,
					);
				} catch (error) {
					console.error('PromptChatAgent failed', error);
				}
			}
		},
		[chatId],
	);

	const notifyTyping = useCallback(() => {
		if (!chatId) {
			return;
		}
		const hub = hubRef.current;
		if (!hub || hub.state !== HubConnectionState.Connected) {
			return;
		}
		const now = Date.now();
		if (now - lastTypingNotifyRef.current < 1200) {
			return;
		}
		lastTypingNotifyRef.current = now;
		void hub.invoke('NotifyTyping', chatId);
	}, [chatId]);

	return {
		firstParticipant,
		hubReady,
		mappedMessages,
		peerIsTyping,
		notifyTyping,
		sendMessage,
	};
}
