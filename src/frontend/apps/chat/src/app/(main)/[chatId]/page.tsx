'use client';

import { ChatFeature } from '@/features';
import {
	useChatParticipants,
	useCurrentProfile,
	useCurrentProfileChats,
	useMessageHistory,
	useUpdateChatSettings,
} from '@/shared';
import { useParams } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';

function ChatPage() {
	const { chatId } = useParams<{ chatId: string }>();
	const { currentProfile } = useCurrentProfile();
	const { chats, getCurrentProfileChats } = useCurrentProfileChats();
	const { participants, getChatParticipants } = useChatParticipants();
	const { messages: historyMessages, getMessageHistory } =
		useMessageHistory();
	const { updateChatSettings, loading: updatingChatSettings } =
		useUpdateChatSettings();
	const [isSettingsDialogOpen, setIsSettingsDialogOpen] = useState(false);
	const [aiEnabled, setAiEnabled] = useState(false);
	const currentChat = chats.find((chat) => chat.id === chatId);

	const messageParticipants = useMemo(() => {
		return ChatFeature.mapMessageParticipants(participants);
	}, [participants]);

	const firstParticipant = useMemo(() => {
		return ChatFeature.getPrimaryParticipant(
			messageParticipants,
			currentProfile?.id,
		);
	}, [currentProfile?.id, messageParticipants]);

	const mappedMessages = useMemo(() => {
		return ChatFeature.buildMappedMessages({
			historyMessages,
			participants: messageParticipants,
			currentProfileId: currentProfile?.id,
		});
	}, [currentProfile?.id, historyMessages, messageParticipants]);

	useEffect(() => {
		if (!chatId) {
			return;
		}

		getChatParticipants(chatId, { includeAgents: true });
	}, [chatId, getChatParticipants]);

	useEffect(() => {
		if (!chatId) {
			return;
		}

		getMessageHistory({
			chatId,
			count: 100,
			offset: 0,
		});
	}, [chatId, getMessageHistory]);

	const handleOpenSettings = () => {
		setAiEnabled(currentChat?.aiEnabled ?? false);
		setIsSettingsDialogOpen(true);
	};

	const handleSaveSettings = async () => {
		if (!chatId) {
			return;
		}

		await updateChatSettings({
			chatId,
			aiEnabled,
		});
		await getCurrentProfileChats();
		setIsSettingsDialogOpen(false);
	};

	return (
		<div className='h-screen flex flex-col'>
			<ChatFeature.ChatHeader
				participant={firstParticipant}
				onOpenSettings={handleOpenSettings}
			/>
			<ChatFeature.ChatMessages messages={mappedMessages} />
			<ChatFeature.ChatComposer aiEnabled={Boolean(currentChat?.aiEnabled)} />
			<ChatFeature.ChatSettingsDialog
				isOpen={isSettingsDialogOpen}
				aiEnabled={aiEnabled}
				loading={updatingChatSettings}
				chatId={chatId}
				onOpenChange={setIsSettingsDialogOpen}
				onAiEnabledChange={setAiEnabled}
				onSave={handleSaveSettings}
			/>
		</div>
	);
}

export default ChatPage;
