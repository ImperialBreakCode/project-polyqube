import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Separator } from '@repo/ui/components/ui/Separator';
import { Search } from 'lucide-react';
import Link from 'next/link';
import React from 'react';

function ChatListMenu() {
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
			<Link
				href={'#'}
				className='flex items-center gap-x-2 px-4 py-2 hover:bg-[#333]
					rounded-md'
			>
				<Avatar className='h-8 w-8 rounded-full'>
					<AvatarImage src={'...'} alt={'alt text'} />
					<AvatarFallback className='rounded-full uppercase'>
						TC
					</AvatarFallback>
				</Avatar>{' '}
				Thomas Collin
			</Link>
		</div>
	);
}

export default ChatListMenu;
