'use client';

import { ReactNode } from 'react';
import { motion, Variants } from 'motion/react';
import { useMenuPanelState } from '../hooks';

interface MainPageWrapperProps {
	children: ReactNode;
}

const MainPageWrapper = ({ children }: MainPageWrapperProps) => {
	const { isMenuOpen } = useMenuPanelState();

	const pageWrapperVariants: Variants = {
		onMenuOpen: {
			scale: 1.2,
		},
		onMenuClosed: {
			scale: 1,
		},
	};

	return (
		<motion.div
			animate={isMenuOpen ? 'onMenuOpen' : 'onMenuClosed'}
			variants={pageWrapperVariants}
			transition={{
				type: 'tween',
			}}
		>
			{children}
		</motion.div>
	);
};

export default MainPageWrapper;
