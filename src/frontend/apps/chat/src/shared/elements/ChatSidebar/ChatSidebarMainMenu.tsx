import { MessageCircleMore } from 'lucide-react';
import Link from 'next/link';
import {
	SidebarGroup,
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
} from '@repo/ui/components/ui/Sidebar';
import { ROUTE_PATHS } from '@/shared/constants';

const ChatSidebarMainMenu = () => {
	return (
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
	);
};

export default ChatSidebarMainMenu;
