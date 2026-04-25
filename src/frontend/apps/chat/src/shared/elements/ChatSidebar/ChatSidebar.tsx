'use client';

import { Ellipsis, LogOut, Menu, MessageCircleMore } from 'lucide-react';
import {
	Sidebar,
	SidebarContent,
	SidebarFooter,
	SidebarGroup,
	SidebarHeader,
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
	useSidebar,
} from '@repo/ui/components/ui/Sidebar';
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
import { Button } from '@repo/ui/components/ui/Button';
import Link from 'next/link';
import { ROUTE_PATHS } from '@/shared/constants';

const ChatSidebar = () => {
	const { toggleSidebar } = useSidebar();

	return (
		<Sidebar collapsible='icon' variant='sidebar'>
			<SidebarHeader>
				<div className='flex overflow-hidden'>
					<div className='flex items-center justify-center py-2 gap-2'>
						<Button
							onClick={toggleSidebar}
							className='bg-transparent
								hover:bg-muted-foreground/10 cursor-pointer
								px-2'
						>
							<Menu className='text-white' />
						</Button>

						<h1
							className='text-xl transition-all duration-200
								ease-in-out opacity-100 translate-x-0
								group-data-[state=collapsed]:opacity-0
								group-data-[state=collapsed]:-translate-x-2
								group-data-[state=collapsed]:w-0
								whitespace-nowrap text-muted-foreground
								uppercase leading-tight'
						>
							PolyQube Chat
						</h1>
					</div>
				</div>
			</SidebarHeader>

			<SidebarContent>
				<SidebarGroup>
					<SidebarMenu>
						<SidebarMenuItem>
							<SidebarMenuButton isActive={true} asChild>
								<Link href={ROUTE_PATHS.home}>
									<MessageCircleMore /> Chat
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
										data-[state=open]:text-sidebar-accent-foreground
										cursor-pointer'
								>
									<Avatar className='h-8 w-8 rounded-lg'>
										<AvatarImage
											src={'...'}
											alt={'alt text'}
										/>
										<AvatarFallback
											className='rounded-lg uppercase'
										>
											US
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
											em@em.com
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

export default ChatSidebar;
