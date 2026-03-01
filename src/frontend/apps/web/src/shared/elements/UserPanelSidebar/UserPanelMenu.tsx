'use client';

import { ReactNode } from 'react';
import Link from 'next/link';
import { House } from 'lucide-react';
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
		title: 'Second',
		url: '#',
		icon: <House />,
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
									`py-5 px-5 rounded-[100px!important] border
									border-transparent transition-colors`,
									pathname.startsWith(x.url)
										? `bg-(--primary-color)
											hover:bg-[var(--primary-hover)!important]
											border-b-(--border-pirmary)
											border-l-(--border-pirmary)
											border-t-(--border-primary-2)
											border-r-(--border-primary-2)`
										: '',
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
