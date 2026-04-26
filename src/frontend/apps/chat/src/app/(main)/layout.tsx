import { ChatListMenu, ChatSidebar } from '@/shared';
import { SidebarInset, SidebarProvider } from '@repo/ui/components/ui/Sidebar';

function MainLayout({ children }: { children: React.ReactNode }) {
	return (
		<div>
			<SidebarProvider defaultOpen={false}>
				<ChatSidebar />
				<SidebarInset>
					<div className='flex flex-row h-screen'>
						<ChatListMenu />
						<div>{children}</div>
					</div>
				</SidebarInset>
			</SidebarProvider>
		</div>
	);
}

export default MainLayout;
