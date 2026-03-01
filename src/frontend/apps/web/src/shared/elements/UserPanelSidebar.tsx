'use client';

import Link from 'next/link';
import {
	BadgeCheck,
	Bell,
	ChevronsUpDown,
	Cog,
	CreditCard,
	House,
	LogOut,
	Sparkles,
} from 'lucide-react';
import {
	Sidebar,
	SidebarContent,
	SidebarFooter,
	SidebarGroup,
	SidebarGroupLabel,
	SidebarHeader,
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

const UserPanelSidebar = () => {
	return (
		<Sidebar collapsible='offcanvas' variant='sidebar'>
			<SidebarHeader>
				<div className='flex items-center py-10 px-2'>
					<h1
						className='text-xl font-semibold flex gap-x-3
							items-center'
					>
						<Cog />
						User Control Panel
					</h1>
				</div>
			</SidebarHeader>
			<SidebarContent>
				<SidebarGroup>
					<SidebarGroupLabel>Menu</SidebarGroupLabel>
					<SidebarMenu>
						<SidebarMenuItem>
							<SidebarMenuButton asChild tooltip={'Home'}>
								<Link href={'#'}>
									<House />
									Home
								</Link>
							</SidebarMenuButton>
						</SidebarMenuItem>
					</SidebarMenu>
				</SidebarGroup>
			</SidebarContent>

			<SidebarFooter>
				<SidebarMenu>
					<SidebarMenuItem>
						<DropdownMenu>
							<DropdownMenuTrigger asChild>
								<SidebarMenuButton
									size='lg'
									className='data-[state=open]:bg-sidebar-accent
										data-[state=open]:text-sidebar-accent-foreground'
								>
									<Avatar className='h-8 w-8 rounded-lg'>
										<AvatarImage
											src={'...'}
											alt={'alt text'}
										/>
										<AvatarFallback className='rounded-lg'>
											CN
										</AvatarFallback>
									</Avatar>
									<div
										className='grid flex-1 text-left text-sm
											leading-tight'
									>
										<span className='truncate font-medium'>
											name name
										</span>
										<span className='truncate text-xs'>
											email@email.mail
										</span>
									</div>
									<ChevronsUpDown className='ml-auto size-4' />
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
										className='flex items-center gap-2 px-1
											py-1.5 text-left text-sm'
									>
										<Avatar className='h-8 w-8 rounded-lg'>
											<AvatarImage
												src={'...'}
												alt={'alt text'}
											/>
											<AvatarFallback className='rounded-lg'>
												CN
											</AvatarFallback>
										</Avatar>
										<div
											className='grid flex-1 text-left
												text-sm leading-tight'
										>
											<span
												className='truncate font-medium'
											>
												name name
											</span>
											<span className='truncate text-xs'>
												email@email.mail
											</span>
										</div>
									</div>
								</DropdownMenuLabel>
								<DropdownMenuSeparator />
								<DropdownMenuGroup>
									<DropdownMenuItem>
										<Sparkles />
										Upgrade to Pro
									</DropdownMenuItem>
								</DropdownMenuGroup>
								<DropdownMenuSeparator />
								<DropdownMenuGroup>
									<DropdownMenuItem>
										<BadgeCheck />
										Account
									</DropdownMenuItem>
									<DropdownMenuItem>
										<CreditCard />
										Billing
									</DropdownMenuItem>
									<DropdownMenuItem>
										<Bell />
										Notifications
									</DropdownMenuItem>
								</DropdownMenuGroup>
								<DropdownMenuSeparator />
								<DropdownMenuItem>
									<LogOut />
									Log out
								</DropdownMenuItem>
							</DropdownMenuContent>
						</DropdownMenu>
					</SidebarMenuItem>
				</SidebarMenu>
			</SidebarFooter>
		</Sidebar>
	);
};

export default UserPanelSidebar;
