'use client';

import { useMenuPanelActions } from '@/shared/hooks';
import { Button } from '@repo/ui/core';
import { cn } from '@repo/ui/lib/utils';

interface CloseNavPanelButtonProps {
	className?: string;
}

const CloseNavPanelButton = ({ className }: CloseNavPanelButtonProps) => {
	const { closeMenu } = useMenuPanelActions();

	return (
		<Button
			className={cn(
				`text-md rounded-full bg-[#503c7c] p-7 cursor-pointer
				hover:bg-white hover:text-black uppercase`,
				className,
			)}
			onClick={() => closeMenu()}
		>
			Close Menu
		</Button>
	);
};

export default CloseNavPanelButton;
