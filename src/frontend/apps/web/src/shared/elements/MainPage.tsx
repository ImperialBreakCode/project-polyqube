'use client';

import { ReactNode } from 'react';
import { motion } from 'motion/react';

interface MainPageProps {
	children: ReactNode;
}

function MainPage({ children }: MainPageProps) {
	return (
		<motion.div
			initial={{
				x: -100,
				opacity: 0,
			}}
			animate={{
				x: 0,
				opacity: 1,
			}}
			exit={{
				x: 100,
				opacity: 0,
			}}
			transition={{
				type: 'tween',
			}}
		>
			{children}
		</motion.div>
	);
}

export default MainPage;
