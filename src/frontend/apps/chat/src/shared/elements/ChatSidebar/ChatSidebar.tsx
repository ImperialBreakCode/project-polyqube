'use client';

import { Menu } from 'lucide-react';
import {
	Sidebar,
	SidebarHeader,
	useSidebar,
} from '@repo/ui/components/ui/Sidebar';
import { Button } from '@repo/ui/components/ui/Button';

const ChatSidebar = () => {
	const { toggleSidebar } = useSidebar();

	return (
		<Sidebar collapsible='icon' variant='sidebar'>
			<SidebarHeader>
				<div className='flex overflow-hidden'>
					<div className='flex items-center justify-center py-2 gap-2'>
						<Button
							onClick={toggleSidebar}
							className='bg-transparent
								hover:bg-muted-foreground/10 cursor-pointer
								px-2'
						>
							<Menu className='text-white' />
						</Button>

						<h1
							className='text-xl transition-all duration-200
								ease-in-out opacity-100 translate-x-0
								group-data-[state=collapsed]:opacity-0
								group-data-[state=collapsed]:-translate-x-2
								group-data-[state=collapsed]:w-0
								whitespace-nowrap text-muted-foreground
								uppercase leading-tight'
						>
							PolyQube Chat
						</h1>
					</div>
				</div>
			</SidebarHeader>
		</Sidebar>
	);
};

export default ChatSidebar;
