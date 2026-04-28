'use client';

import {
	Sidebar,
	SidebarContent,
	SidebarFooter,
	SidebarHeader,
} from '@repo/ui/components/ui/Sidebar';

import ChatSidebarUser from './ChatSidebarUser';
import ChatSidebarMainMenu from './ChatSidebarMainMenu';
import ChatSidebarHeading from './ChatSidebarHeading';

const ChatSidebar = () => {
	return (
		<Sidebar collapsible='icon' variant='sidebar'>
			<SidebarHeader>
				<ChatSidebarHeading />
			</SidebarHeader>

			<SidebarContent>
				<ChatSidebarMainMenu />
			</SidebarContent>

			<SidebarFooter>
				<ChatSidebarUser />
			</SidebarFooter>
		</Sidebar>
	);
};

export default ChatSidebar;
