'use client';

import { useMenuPanelActions } from '@/shared/hooks';
import { Button } from '@repo/ui/core';

const CloseNavPanelButton = () => {
	const { closeMenu } = useMenuPanelActions();

	return (
		<Button
			className='text-md rounded-full bg-[#503c7c] p-7 cursor-pointer
				hover:bg-white hover:text-black uppercase'
			onClick={() => closeMenu()}
		>
			Close Menu
		</Button>
	);
};

export default CloseNavPanelButton;
