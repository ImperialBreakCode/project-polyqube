'use client';

import { BsThreeDots } from 'react-icons/bs';
import { useCurrentProfileChats, useUpdateChatSettings } from '@/shared';
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
import { useState } from 'react';

function ChatPage() {
	const { chatId } = useParams<{ chatId: string }>();
	const { chats, getCurrentProfileChats } = useCurrentProfileChats();
	const { updateChatSettings, loading: updatingChatSettings } =
		useUpdateChatSettings();
	const [isSettingsDialogOpen, setIsSettingsDialogOpen] = useState(false);
	const [aiEnabled, setAiEnabled] = useState(false);
	const currentChat = chats.find((chat) => chat.id === chatId);

	const messages = [
		{
			id: 1,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:24',
			text: 'Hey team, quick placeholder message for the chat UI preview.',
		},
		{
			id: 2,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:25',
			text: 'Looks good. We can keep this style and wire data later.',
		},
		{
			id: 3,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:26',
			text: 'Perfect, only visual placeholders for now. No backend needed.',
		},
		{
			id: 4,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:27',
			text: 'Great. Sending one more example bubble to show spacing.',
		},
		{
			id: 5,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:28',
			text: 'Can we also verify how long messages wrap in this layout?',
		},
		{
			id: 6,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:29',
			text: 'Sure. This is a slightly longer placeholder text to check wrapping, line-height, and overall readability inside the bubble.',
		},
		{
			id: 7,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:30',
			text: 'Nice, spacing between avatar, header row, and message body feels balanced.',
		},
		{
			id: 8,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:31',
			text: 'Keeping this simple for now with placeholders only.',
		},
		{
			id: 9,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:32',
			text: 'Perfect. We can replace these with real data in the next step.',
		},
		{
			id: 10,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:33',
			text: 'Adding extra placeholders so the scroll behavior is easier to evaluate.',
		},
		{
			id: 11,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:34',
			text: 'Great call. It helps confirm alignment with longer chat history.',
		},
		{
			id: 12,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:35',
			text: 'We should keep tone and spacing consistent across all bubbles.',
		},
		{
			id: 13,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:36',
			text: 'Yes, this already feels close to the current color system.',
		},
		{
			id: 14,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:37',
			text: 'Another short placeholder.',
		},
		{
			id: 15,
			name: 'Thomas Collin',
			initials: 'TC',
			side: 'left',
			time: '12:38',
			text: 'And one more from me so both sides stay balanced.',
		},
		{
			id: 16,
			name: 'You',
			initials: 'YO',
			side: 'right',
			time: '12:39',
			text: 'Done. UI-only list remains static and disconnected from backend.',
		},
	];

	return (
		<div className='h-screen flex flex-col'>
			<div className='flex px-2 py-4 bg-[#28232d]'>
				<div className='flex items-center gap-x-2'>
					<Avatar className='h-8 w-8 rounded-full'>
						<AvatarImage src={'...'} alt={''} />
						<AvatarFallback
							className='rounded-full uppercase bg-transparent'
						>
							TC
						</AvatarFallback>
					</Avatar>{' '}
					<p>Thomas Collin</p>
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
						{messages.map((message) => {
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
												src={'...'}
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
												<span>{message.time}</span>
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
				<Button
					variant={'outline'}
					className='rounded-full border-[#686868]'
				>
					<Sparkles />
				</Button>
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
