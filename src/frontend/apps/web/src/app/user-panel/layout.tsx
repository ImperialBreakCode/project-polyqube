import { ReactNode } from 'react';
import { SidebarProvider, SidebarTrigger } from '@repo/ui/core';
import { UserPanelSidebar } from '@/shared/elements';

function UserPanelLayout({ children }: { children: ReactNode }) {
	return (
		<SidebarProvider>
			<UserPanelSidebar />
			<main>
				<SidebarTrigger />
				{children}
			</main>
		</SidebarProvider>
	);
}

export default UserPanelLayout;
