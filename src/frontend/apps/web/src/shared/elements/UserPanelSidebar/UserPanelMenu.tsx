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
];

const UserPanelMenu = () => {
	const pathname = usePathname();

	return (
		<SidebarGroup>
			<SidebarGroupLabel>Menu</SidebarGroupLabel>
			<SidebarMenu>
				{routesData.map((x) => (
					<SidebarMenuItem key={x.title}>
						<SidebarMenuButton asChild tooltip={'Home'}>
							<Link
								href={x.url}
								className={
									pathname.startsWith(x.url)
										? 'bg-sidebar-accent'
										: ''
								}
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
