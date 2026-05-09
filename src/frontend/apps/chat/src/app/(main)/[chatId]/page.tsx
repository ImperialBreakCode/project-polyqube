'use client';

import { BsThreeDots } from 'react-icons/bs';
import {
	useChatParticipants,
	useCurrentProfile,
	useCurrentProfileChats,
	useMessageHistory,
	useUpdateChatSettings,
} from '@/shared';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Button } from '@repo/ui/components/ui/Button';
import {
	Dialog,
	DialogContent,
	DialogFooter,
	DialogHeader,
	DialogTitle,
} from '@repo/ui/components/ui/Dialog';
import { Input } from '@repo/ui/components/ui/Input';
import { ScrollArea } from '@repo/ui/components/ui/ScrollArea';
import { Switch } from '@repo/ui/components/ui/Switch';
import { SendHorizontal, Sparkles } from 'lucide-react';
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
		return participants.map((participant) => {
			const profileName = participant.userProfile?.fullName ?? null;
			const agentName = participant.chatAgent?.agentName ?? null;
			const displayName =
				participant.chatNickname ?? profileName ?? agentName ?? '';

			return {
				id: participant.id,
				displayName,
				userProfileId: participant.userProfile?.id ?? null,
				profilePicture:
					participant.userProfile?.profilePicture ??
					participant.chatAgent?.profilePicture ??
					null,
				isBot: Boolean(participant.chatAgent),
			};
		});
	}, [participants]);

	const firstParticipant =
		messageParticipants.find(
			(participant) => participant.userProfileId !== currentProfile?.id,
		) ?? messageParticipants[0];

	const participantsById = useMemo(() => {
		return new Map(
			messageParticipants.map((participant) => [
				participant.id,
				participant,
			]),
		);
	}, [messageParticipants]);

	const mappedMessages = useMemo(() => {
		return historyMessages.map((message, index) => {
			const participant = message.participantId
				? participantsById.get(message.participantId)
				: undefined;
			const name = participant?.displayName ?? 'Unknown';
			const initials = name.slice(0, 2).toUpperCase();
			const isCurrentUser = Boolean(
				participant?.userProfileId &&
				currentProfile?.id &&
				participant.userProfileId === currentProfile.id,
			);
			const isBot = participant?.isBot ?? message.messageType === 1;

			return {
				id: `${message.participantId ?? 'none'}-${index}`,
				name,
				initials,
				side: isCurrentUser ? 'right' : 'left',
				text: message.textContent,
				profilePicture: participant?.profilePicture ?? '...',
				isBot,
			};
		});
	}, [currentProfile, historyMessages, participantsById]);

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

	return (
		<div className='h-screen flex flex-col'>
			<div className='flex px-2 py-4 bg-[#28232d]'>
				<div className='flex items-center gap-x-2'>
					<Avatar className='h-8 w-8 rounded-full'>
						<AvatarImage
							src={firstParticipant?.profilePicture ?? '...'}
							alt={firstParticipant?.displayName ?? ''}
						/>
						<AvatarFallback
							className='rounded-full uppercase bg-transparent'
						>
							{firstParticipant?.displayName?.slice(0, 2) ?? 'TC'}
						</AvatarFallback>
					</Avatar>{' '}
					<p>{firstParticipant?.displayName ?? 'Thomas Collin'}</p>
				</div>

				<Button
					className='rounded-full ms-auto hover:bg-[#84848445]'
					variant={'ghost'}
					onClick={() => {
						setAiEnabled(currentChat?.aiEnabled ?? false);
						setIsSettingsDialogOpen(true);
					}}
				>
					<BsThreeDots />
				</Button>
			</div>

			<ScrollArea className='flex-1'>
				<div className='min-h-full px-3 py-4'>
					<div
						className='mx-auto flex w-full max-w-4xl flex-col gap-3'
					>
						{mappedMessages.map((message) => {
							const isCurrentUser = message.side === 'right';

							return (
								<div
									key={message.id}
									className={`flex w-full
									${isCurrentUser ? 'justify-end' : 'justify-start'}`}
								>
									<div
										className={`flex max-w-[78%] gap-2
										${isCurrentUser ? 'flex-row-reverse' : 'flex-row'}`}
									>
										<Avatar
											className='mt-0.5 h-8 w-8
												rounded-full border
												border-[#4a4a4a]'
										>
											<AvatarImage
												src={message.profilePicture}
												alt={message.name}
											/>
											<AvatarFallback
												className='rounded-full
													bg-[#242129] text-xs
													uppercase text-[#d4d4d4]'
											>
												{message.initials}
											</AvatarFallback>
										</Avatar>

										<div
											className={`rounded-2xl border px-3
											py-2 ${
												isCurrentUser
													? `border-[#4d4354]
														bg-[#3a3340]`
													: `border-[#464646]
														bg-[#2f2f2f]`
											}`}
										>
											<div
												className={`mb-1 flex
												items-center gap-2 text-xs
												text-[#b8b8b8]
												${isCurrentUser ? 'justify-end' : 'justify-start'}`}
											>
												<span
													className='font-medium
														text-[#e7e7e7]'
												>
													{message.name}
												</span>
												{message.isBot && (
													<span
														className='rounded-full
															border
															border-[#5a5a5a]
															px-2 py-0.5
															text-[10px]
															uppercase'
													>
														Bot
													</span>
												)}
											</div>
											<p
												className='text-sm
													leading-relaxed
													text-[#ececec]'
											>
												{message.text}
											</p>
										</div>
									</div>
								</div>
							);
						})}
					</div>
				</div>
			</ScrollArea>

			<div className='flex mt-auto pt-4 pb-10 px-2'>
				{currentChat?.aiEnabled && (
					<Button
						variant={'outline'}
						className='rounded-full border-[#686868]'
					>
						<Sparkles />
					</Button>
				)}
				<Input className='rounded-full border-[#686868]' />
				<Button className='rounded-full'>
					<SendHorizontal />
				</Button>
			</div>

			<Dialog
				open={isSettingsDialogOpen}
				onOpenChange={setIsSettingsDialogOpen}
			>
				<DialogContent showCloseButton>
					<DialogHeader>
						<DialogTitle>Chat settings</DialogTitle>
					</DialogHeader>
					<div className='py-2'>
						<label
							htmlFor='aiEnabled'
							className='flex items-center justify-between gap-3'
						>
							<span>AI enabled</span>
							<Switch
								id='aiEnabled'
								checked={aiEnabled}
								onCheckedChange={setAiEnabled}
								disabled={updatingChatSettings}
							/>
						</label>
					</div>
					<DialogFooter>
						<Button
							variant='outline'
							onClick={() => setIsSettingsDialogOpen(false)}
							disabled={updatingChatSettings}
						>
							Cancel
						</Button>
						<Button
							onClick={async () => {
								if (!chatId) {
									return;
								}

								await updateChatSettings({
									chatId,
									aiEnabled,
								});
								await getCurrentProfileChats();
								setIsSettingsDialogOpen(false);
							}}
							disabled={updatingChatSettings || !chatId}
						>
							Save
						</Button>
					</DialogFooter>
				</DialogContent>
			</Dialog>
		</div>
	);
}

export default ChatPage;
