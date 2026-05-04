'use client';

import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuItem,
	DropdownMenuTrigger,
} from '@repo/ui/components/ui/DropdownMenu';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import {
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
} from '@repo/ui/components/ui/Sidebar';
import { Ellipsis, LogOut } from 'lucide-react';
import { useLogout } from '@/features/auth';
import { useCurrentProfile } from '@/shared';

const ChatSidebarUser = () => {
	const { logout } = useLogout();
	const { currentProfile } = useCurrentProfile();

	const firstName = currentProfile?.firstName ?? '';
	const lastName = currentProfile?.lastName ?? '';
	const fullName = `${firstName} ${lastName}`.trim() || 'User';
	const initials = `${firstName[0] ?? ''}${lastName[0] ?? ''}` || 'US';

	return (
		<SidebarMenu>
			<SidebarMenuItem>
				<DropdownMenu>
					<DropdownMenuTrigger asChild>
						<SidebarMenuButton
							size='lg'
							className='data-[state=open]:bg-sidebar-accent
								data-[state=open]:text-sidebar-accent-foreground
								cursor-pointer'
						>
							<Avatar className='h-8 w-8 rounded-lg'>
								<AvatarImage
									src={currentProfile?.profilePicture}
									alt={fullName}
								/>
								<AvatarFallback className='rounded-lg uppercase'>
									{initials}
								</AvatarFallback>
							</Avatar>
							<div
								className='grid flex-1 text-left text-sm
									leading-tight'
							>
								<span className='truncate font-medium'>
									{fullName}
								</span>
							</div>
							<Ellipsis className='ml-auto size-4' />
						</SidebarMenuButton>
					</DropdownMenuTrigger>
					<DropdownMenuContent
						className='w-(--radix-dropdown-menu-trigger-width)
							min-w-56 rounded-lg'
						side={'bottom'}
						align='end'
						sideOffset={4}
					>
						<DropdownMenuItem onClick={async () => await logout()}>
							<LogOut />
							Log out
						</DropdownMenuItem>
					</DropdownMenuContent>
				</DropdownMenu>
			</SidebarMenuItem>
		</SidebarMenu>
	);
};

export default ChatSidebarUser;
