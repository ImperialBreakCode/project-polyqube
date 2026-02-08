import { ReactNode } from 'react';
import Link from 'next/link';

import { MainNav, NavPanelWrapper, PageWrapper } from '@/shared';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div className='overflow-x-hidden'>
			<NavPanelWrapper />
			<header>
				<div
					className='fixed z-20 flex w-screen justify-end
						md:justify-center text-white'
				>
					<MainNav />
				</div>
			</header>
			<main className='bg-zinc-900 text-white'>
				<PageWrapper>{children}</PageWrapper>
			</main>
			<footer
				className='py-10 px-5 sm:px-20 bg-zinc-900 text-white flex
					flex-col space-y-15 text-xl md:text-3xl'
			>
				<p className='border-b border-b-[#ffffff49]'>PolyQube</p>
				<div
					className='text-sm font-urbanist-italic flex justify-center
						space-x-5'
				>
					<Link href={'#'}>Home</Link>
					<p>-</p>
					<Link href={'#'}>About</Link>
					<p>-</p>
					<Link href={'#'}>Services</Link>
					<p>-</p>
					<Link href={'#'}>Login</Link>
				</div>
				<p className='text-right border-t border-t-[#ffffff49]'>2025</p>
			</footer>
		</div>
	);
}

export default LandingLayout;
