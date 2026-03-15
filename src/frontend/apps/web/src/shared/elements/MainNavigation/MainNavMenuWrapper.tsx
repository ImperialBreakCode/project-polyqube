'use client';

import { ReactNode, useState } from 'react';
import { useMotionValueEvent, useScroll } from 'motion/react';

import { NavigationMenu } from '@repo/ui/core';
import { cn } from '@repo/ui/lib/utils';

import OpenNavPanelButton from '../OpenNavPanelButton';

interface MainNavMenuWrapperProps {
	children?: ReactNode;
}

const MainNavMenuWrapper = ({ children }: MainNavMenuWrapperProps) => {
	const { scrollYProgress } = useScroll();
	const [navbarContained, setNavbarContained] = useState(false);

	useMotionValueEvent(scrollYProgress, 'change', (latest) => {
		if (latest > 0.07) {
			setNavbarContained(true);
		} else {
			setNavbarContained(false);
		}
	});

	return (
		<>
			<NavigationMenu
				className={cn(
					`m-10 justify-between rounded-full p-5 transform
					duration-400 ease-[cubic-bezier(0.1,0.21, 0.01, 0.86)]
					hidden md:flex`,
					navbarContained
						? 'bg-[#5050508e] w-[68vw] backdrop-blur-lg'
						: 'w-screen',
				)}
			>
				{children}
			</NavigationMenu>
			<OpenNavPanelButton contained={navbarContained} />
		</>
	);
};

export default MainNavMenuWrapper;
