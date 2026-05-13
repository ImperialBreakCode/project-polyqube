'use client';

import type { ChatMessageViewModel } from '../types';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { ScrollArea } from '@repo/ui/components/ui/ScrollArea';

type ChatMessagesProps = {
	messages: ChatMessageViewModel[];
	peerIsTyping?: boolean;
};

function ChatMessages({ messages, peerIsTyping }: ChatMessagesProps) {
	return (
		<ScrollArea className='flex-1'>
			<div className='min-h-full px-3 py-4'>
				<div className='mx-auto flex w-full max-w-4xl flex-col gap-3'>
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
										className='mt-0.5 h-8 w-8 rounded-full
											border border-[#4a4a4a]'
									>
										<AvatarImage
											src={
												message.isBot
													? '/ramsay.jpg'
													: message.profilePicture
											}
											alt={message.name}
										/>
										<AvatarFallback
											className='rounded-full bg-[#242129]
												text-xs uppercase
												text-[#d4d4d4]'
										>
											{message.initials}
										</AvatarFallback>
									</Avatar>

									<div
										className={`rounded-2xl border px-3 py-2
										${
											isCurrentUser
												? `border-[#4d4354]
													bg-[#3a3340]`
												: `border-[#464646]
													bg-[#2f2f2f]`
										}`}
									>
										<div
											className={`mb-1 flex items-center
											gap-2 text-xs text-[#b8b8b8] ${
												isCurrentUser
													? 'justify-end'
													: 'justify-start'
											}`}
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
														border border-[#5a5a5a]
														px-2 py-0.5 text-[10px]
														uppercase'
												>
													Bot
												</span>
											)}
										</div>
										<p
											className='text-sm leading-relaxed
												text-[#ececec]'
										>
											{message.text}
										</p>
									</div>
								</div>
							</div>
						);
					})}
					{peerIsTyping && (
						<div className='pl-11 text-sm italic text-[#9a9a9a]'>
							Typing…
						</div>
					)}
				</div>
			</div>
		</ScrollArea>
	);
}

export default ChatMessages;
