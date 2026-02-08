'use client';

import { RxHamburgerMenu } from 'react-icons/rx';
import { Button } from '@repo/ui/core';
import { cn } from '@repo/ui/lib/utils';
import { useMenuPanelActions } from '../hooks';

interface OpenNavPanelButtonProps {
	contained?: boolean;
}

const OpenNavPanelButton = ({ contained }: OpenNavPanelButtonProps) => {
	const { openMenu } = useMenuPanelActions();

	return (
		<div
			className={cn(
				`my-10 me-10 items-center flex rounded-full duration-400
				ease-[cubic-bezier(0.1,0.21, 0.01, 0.86)] border-[.1px]
				overflow-hidden justify-center`,
				contained
					? 'bg-[#5050508e] backdrop-blur-lg border-[#ffffff00]'
					: 'border-[#ffffff50] hover:border-[#c3c3c376]',
			)}
		>
			<Button
				className='p-5 px-10 h-full bg-transparent cursor-pointer
					hover:bg-[#dadada] hover:text-[#000000]'
				onClick={() => openMenu()}
			>
				<RxHamburgerMenu />
			</Button>
		</div>
	);
};

export default OpenNavPanelButton;
