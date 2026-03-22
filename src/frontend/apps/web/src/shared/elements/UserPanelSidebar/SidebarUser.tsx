'use client';

import { Ellipsis, Home, LogOut } from 'lucide-react';
import {
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
} from '@repo/ui/components/ui/Sidebar';
import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuGroup,
	DropdownMenuItem,
	DropdownMenuLabel,
	DropdownMenuSeparator,
	DropdownMenuTrigger,
} from '@repo/ui/components/ui/DropdownMenu';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { useCurrentUser, useLogout } from '@/shared/api';
import Link from 'next/link';
import { ROUTE_PATHS } from '@/shared/constants';
import { useRouter } from 'next/navigation';

const SidebarUser = () => {
	const router = useRouter();
	const { logout, logoutLoading } = useLogout();
	const { currentUser } = useCurrentUser();

	const avatar = (
		<Avatar className='h-8 w-8 rounded-lg'>
			<AvatarImage
				src={currentUser?.userDetails?.profilePicturePath}
				alt={'alt text'}
			/>
			<AvatarFallback className='rounded-lg uppercase'>
				{currentUser?.userDetails?.firstName[0]}
				{currentUser?.userDetails?.lastName[0]}
			</AvatarFallback>
		</Avatar>
	);

	const userInfo = (
		<div className='grid flex-1 text-left text-sm leading-tight'>
			<span className='truncate font-medium'>
				{currentUser?.userDetails?.firstName}{' '}
				{currentUser?.userDetails?.lastName}
			</span>
			<span className='truncate text-xs'>
				{currentUser?.emails.find((x) => x.isPrimary)?.email}
			</span>
		</div>
	);

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
							{avatar}
							{userInfo}
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
						<DropdownMenuLabel className='p-0 font-normal'>
							<div
								className='flex items-center gap-2 px-1 py-1.5
									text-left text-sm'
							>
								{avatar}
								{userInfo}
							</div>
						</DropdownMenuLabel>
						<DropdownMenuSeparator />
						<DropdownMenuGroup>
							<DropdownMenuItem asChild>
								<Link href={ROUTE_PATHS.home}>
									<Home />
									Landing Area
								</Link>
							</DropdownMenuItem>
						</DropdownMenuGroup>
						<DropdownMenuSeparator />
						<DropdownMenuItem
							disabled={logoutLoading}
							onClick={async () => {
								await logout();
								router.push(ROUTE_PATHS.home);
							}}
						>
							<LogOut />
							Log out
						</DropdownMenuItem>
					</DropdownMenuContent>
				</DropdownMenu>
			</SidebarMenuItem>
		</SidebarMenu>
	);
};

export default SidebarUser;
