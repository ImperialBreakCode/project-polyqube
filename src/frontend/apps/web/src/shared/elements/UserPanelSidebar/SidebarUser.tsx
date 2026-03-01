import { BadgeCheck, Bell, CreditCard, Ellipsis, LogOut } from 'lucide-react';
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

const SidebarUser = () => {
	const avatar = (
		<Avatar className='h-8 w-8 rounded-lg'>
			<AvatarImage src={'...'} alt={'alt text'} />
			<AvatarFallback className='rounded-lg'>CN</AvatarFallback>
		</Avatar>
	);

	const userInfo = (
		<div className='grid flex-1 text-left text-sm leading-tight'>
			<span className='truncate font-medium'>name name</span>
			<span className='truncate text-xs'>email@email.mail</span>
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
								data-[state=open]:text-sidebar-accent-foreground'
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
	);
};

export default SidebarUser;
