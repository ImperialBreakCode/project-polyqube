import { ReactNode } from 'react';
import {
	SidebarInset,
	SidebarProvider,
	SidebarTrigger,
} from '@repo/ui/components/ui/Sidebar';
import { ModeToggle, UserPanelSidebar } from '@/shared/elements';

function UserPanelLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<SidebarProvider
				style={
					{
						'--sidebar-width': '17rem',
						'--sidebar-width-mobile': '17rem',
					} as React.CSSProperties
				}
			>
				<UserPanelSidebar />
				<SidebarInset>
					<header
						className='flex h-16 shrink-0 items-center gap-2
							border-b px-4'
					>
						<SidebarTrigger className='-ml-1' />
						<ModeToggle className='ms-auto' />
					</header>
					<div>{children}</div>
				</SidebarInset>
			</SidebarProvider>
		</div>
	);
}

export default UserPanelLayout;
