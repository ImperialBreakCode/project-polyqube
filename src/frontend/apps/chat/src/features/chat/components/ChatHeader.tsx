'use client';

import type { MessageParticipant } from '../types';
import { BsThreeDots } from 'react-icons/bs';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Button } from '@repo/ui/components/ui/Button';

type ChatHeaderProps = {
	participant?: MessageParticipant;
	onOpenSettings: () => void;
};

function ChatHeader({ participant, onOpenSettings }: ChatHeaderProps) {
	return (
		<div className='flex px-2 py-4 bg-[#28232d]'>
			<div className='flex items-center gap-x-2'>
				<Avatar className='h-8 w-8 rounded-full'>
					<AvatarImage
						src={participant?.profilePicture ?? '...'}
						alt={participant?.displayName ?? ''}
					/>
					<AvatarFallback className='rounded-full uppercase bg-transparent'>
						{participant?.displayName?.slice(0, 2) ?? 'TC'}
					</AvatarFallback>
				</Avatar>
				<p>{participant?.displayName ?? 'Thomas Collin'}</p>
			</div>

			<Button
				className='rounded-full ms-auto hover:bg-[#84848445]'
				variant='ghost'
				onClick={onOpenSettings}
			>
				<BsThreeDots />
			</Button>
		</div>
	);
}

export default ChatHeader;
