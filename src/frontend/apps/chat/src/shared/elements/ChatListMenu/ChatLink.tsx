import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import Link from 'next/link';
import React from 'react';

interface ChatLinkProps {
	avatarSrc: string;
	avatarFallback: string;
	name: string;
	href: string;
}

const ChatLink = ({ avatarSrc, avatarFallback, name, href }: ChatLinkProps) => {
	return (
		<Link
			href={href}
			className='flex items-center gap-x-2 px-4 py-2 hover:bg-[#333]
				rounded-md'
		>
			<Avatar className='h-8 w-8 rounded-full'>
				<AvatarImage src={avatarSrc} alt={name} />
				<AvatarFallback className='rounded-full uppercase'>
					{avatarFallback}
				</AvatarFallback>
			</Avatar>{' '}
			{name}
		</Link>
	);
};

export default ChatLink;
