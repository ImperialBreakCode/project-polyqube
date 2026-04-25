import { ChatSidebar } from '@/shared';
import { SidebarInset, SidebarProvider } from '@repo/ui/components/ui/Sidebar';

function MainLayout({ children }: { children: React.ReactNode }) {
	return (
		<div>
			<SidebarProvider defaultOpen={false}>
				<ChatSidebar />
				<SidebarInset>
					<div>{children}</div>
				</SidebarInset>
			</SidebarProvider>
		</div>
	);
}

export default MainLayout;
