'use client';

import { Separator } from '@repo/ui/components/ui/Separator';
import { Search } from 'lucide-react';
import Link from 'next/link';
import { useCurrentProfileChats } from '@/shared';
import ChatLink from './ChatLink';

function ChatListMenu() {
	const { chats } = useCurrentProfileChats();

	return (
		<div className='border-r flex flex-col items-stretch p-4 w-64'>
			<div className='mb-5'>
				<h2 className='text-center'>Chat List</h2>
			</div>

			<Link
				className='flex justify-center items-center gap-x-4 px-4 py-2
					rounded-md text-center hover:bg-[#333] bg-[#3b3b3b]'
				href='#'
			>
				<Search size={17} /> Start a new Chat
			</Link>
			<Separator className='my-2' />
			{chats.map((chat) => (
				<ChatLink
					key={chat.id}
					name={chat.chatName ?? 'Untitled chat'}
					href={`/${chat.id}`}
				/>
			))}
		</div>
	);
}

export default ChatListMenu;
