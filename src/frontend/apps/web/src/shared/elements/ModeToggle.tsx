'use client';

import { useTheme } from 'next-themes';
import { Moon, Sun } from 'lucide-react';
import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuItem,
	DropdownMenuTrigger,
} from '@repo/ui/components/ui/DropdownMenu';
import { Button } from '@repo/ui/core';

interface ModeToggleProps {
	className?: string;
}

const ModeToggle = ({ className }: ModeToggleProps) => {
	const { setTheme } = useTheme();
	return (
		<div className={className}>
			<DropdownMenu>
				<DropdownMenuTrigger asChild>
					<Button variant='outline' size='icon'>
						<Sun
							className='h-[1.2rem] w-[1.2rem] scale-100 rotate-0
								transition-all dark:scale-0 dark:-rotate-90'
						/>
						<Moon
							className='absolute h-[1.2rem] w-[1.2rem] scale-0
								rotate-90 transition-all dark:scale-100
								dark:rotate-0'
						/>
						<span className='sr-only'>Toggle theme</span>
					</Button>
				</DropdownMenuTrigger>
				<DropdownMenuContent align='end'>
					<DropdownMenuItem onClick={() => setTheme('light')}>
						Light
					</DropdownMenuItem>
					<DropdownMenuItem onClick={() => setTheme('dark')}>
						Dark
					</DropdownMenuItem>
					<DropdownMenuItem onClick={() => setTheme('system')}>
						System
					</DropdownMenuItem>
				</DropdownMenuContent>
			</DropdownMenu>
		</div>
	);
};

export default ModeToggle;
