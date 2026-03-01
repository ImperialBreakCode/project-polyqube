import { Cog } from 'lucide-react';
import {
	Sidebar,
	SidebarContent,
	SidebarFooter,
	SidebarHeader,
} from '@repo/ui/components/ui/Sidebar';
import SidebarUser from './SidebarUser';
import UserPanelMenu from './UserPanelMenu';

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
				<UserPanelMenu />
			</SidebarContent>

			<SidebarFooter>
				<SidebarUser />
			</SidebarFooter>
		</Sidebar>
	);
};

export default UserPanelSidebar;
