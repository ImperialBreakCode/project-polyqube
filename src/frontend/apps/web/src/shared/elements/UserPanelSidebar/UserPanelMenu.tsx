'use client';

import { ReactNode } from 'react';
import Link from 'next/link';
import { House, UserRound } from 'lucide-react';
import { usePathname } from 'next/navigation';
import {
	SidebarGroup,
	SidebarGroupLabel,
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
} from '@repo/ui/components/ui/Sidebar';
import { cn } from '@repo/ui/lib/utils';
import { ROUTE_PATHS } from '@/shared/constants/routes';

type RouteData = {
	title: string;
	url: string;
	icon: ReactNode;
};

const routesData: RouteData[] = [
	{
		title: 'Home dashboard',
		url: ROUTE_PATHS.userPanel.homeDashboard,
		icon: <House />,
	},
	{
		title: 'Personal info',
		url: ROUTE_PATHS.userPanel.personalInfo,
		icon: <UserRound />,
	},
];

const UserPanelMenu = () => {
	const pathname = usePathname();

	return (
		<SidebarGroup>
			<SidebarGroupLabel className='uppercase'>
				Pannel Menu
			</SidebarGroupLabel>
			<SidebarMenu className='gap-y-2'>
				{routesData.map((x) => (
					<SidebarMenuItem key={x.title}>
						<SidebarMenuButton asChild tooltip={'Home'}>
							<Link
								href={x.url}
								className={cn(
									`py-5 px-5 border border-transparent
									transition-colors`,
									pathname === x.url
										? `border-t-[#9459d823]
											border-r-[#9459d823]
											border-b-[#9459d8]
											border-l-[#9459d8] bg-linear-to-r
											dark:from-[#55456878]
											from-[#3b2952a9] dark:to-[#603c89]
											to-[#4b217b] text-white
											hover:from-[#694d8a]
											hover:text-white `
										: `border border-transparent
											hover:border-t-[#d0d0d023]
											hover:border-r-[#d0d0d023]
											hover:border-b-[#d0d0d04a]
											hover:border-l-[#d0d0d04a]
											bg-linear-to-r
											hover:from-[#4343434a]
											hover:to-[#8f8f8f4a]`,
								)}
							>
								{x.icon}
								{x.title}
							</Link>
						</SidebarMenuButton>
					</SidebarMenuItem>
				))}
			</SidebarMenu>
		</SidebarGroup>
	);
};

export default UserPanelMenu;
