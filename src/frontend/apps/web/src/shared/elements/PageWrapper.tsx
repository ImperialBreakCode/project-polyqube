'use client';

import { motion, Variants } from 'motion/react';
import { ReactNode } from 'react';
import { useMenuPanelState } from '../hooks';

interface PageWrapperProps {
	children: ReactNode;
}

const PageWrapper = ({ children }: PageWrapperProps) => {
	const { isMenuOpen } = useMenuPanelState();

	const pageWrapperVariants: Variants = {
		onMenuOpen: {
			scale: 1.2,
			transition: {
				type: 'tween',
			},
		},
		onMenuClosed: {
			scale: 1,
			transition: {
				type: 'tween',
			},
		},
	};

	return (
		<motion.div
			animate={isMenuOpen ? 'onMenuOpen' : 'onMenuClosed'}
			variants={pageWrapperVariants}
		>
			{children}
		</motion.div>
	);
};

export default PageWrapper;
