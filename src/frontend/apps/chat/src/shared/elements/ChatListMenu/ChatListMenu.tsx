'use client';

import { ROUTE_PATHS, useCurrentProfileChats } from '@/shared';
import { Separator } from '@repo/ui/components/ui/Separator';
import { Search } from 'lucide-react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import ChatLink from './ChatLink';

function ChatListMenu() {
	const { chats } = useCurrentProfileChats();
	const pathname = usePathname();
	const isHomeActive = pathname === ROUTE_PATHS.home;

	return (
		<div className='border-r flex flex-col items-stretch p-4 w-64'>
			<div className='mb-5'>
				<h2 className='text-center'>Chat List</h2>
			</div>

			<Link
				className={`flex justify-center items-center gap-x-4 px-4 py-2
					rounded-md text-center transition-colors ${
						isHomeActive
							? 'bg-[#4a3f52] text-white'
							: ' text-[#e2e2e2] hover:bg-[#474747]'
					}`}
				href={ROUTE_PATHS.home}
			>
				<Search size={17} /> Start a new Chat
			</Link>
			<Separator className='my-2' />
			{chats.map((chat) => (
				<ChatLink
					key={chat.id}
					name={chat.chatName ?? 'Untitled chat'}
					href={`/${chat.id}`}
					isActive={pathname === `/${chat.id}`}
				/>
			))}
		</div>
	);
}

export default ChatListMenu;
