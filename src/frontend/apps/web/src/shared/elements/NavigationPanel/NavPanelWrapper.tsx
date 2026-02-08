'use client';

import { useEffect } from 'react';
import { AnimatePresence, motion } from 'motion/react';
import { useMenuPanelState } from '@/shared/hooks';
import NavPanel from './NavPanel';

const MotionNavPanel = motion.create(NavPanel);

const NavPanelWrapper = () => {
	const { isMenuOpen } = useMenuPanelState();

	useEffect(() => {
		document.body.classList.toggle('lock-scroll', isMenuOpen);
		return () => document.body.classList.remove('lock-scroll');
	}, [isMenuOpen]);

	return (
		<AnimatePresence>
			{isMenuOpen && (
				<MotionNavPanel
					key='motion-nav-panel'
					initial={{
						opacity: 0,
						scale: 0.5,
						borderRadius: 100,
					}}
					animate={{
						opacity: 1,
						scale: 1,
						borderRadius: 0,
					}}
					exit={{
						opacity: 0,
						scale: 0.8,
						borderRadius: 100,
						transition: {
							duration: 0.3,
						},
					}}
				/>
			)}
		</AnimatePresence>
	);
};

export default NavPanelWrapper;
