import { ReactNode } from 'react';
import {
	SidebarInset,
	SidebarProvider,
	SidebarTrigger,
} from '@repo/ui/components/ui/Sidebar';
import { UserPanelSidebar } from '@/shared/elements';

function UserPanelLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<SidebarProvider>
				<UserPanelSidebar />
				<SidebarInset>
					<header
						className='flex h-16 shrink-0 items-center gap-2
							border-b px-4'
					>
						<SidebarTrigger className='-ml-1' />
					</header>
					<div>{children}</div>
				</SidebarInset>
			</SidebarProvider>
		</div>
	);
}

export default UserPanelLayout;
