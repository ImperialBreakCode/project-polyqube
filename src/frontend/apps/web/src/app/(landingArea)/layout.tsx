import { ReactNode } from 'react';
import { MainNav } from '@/shared';
import Link from 'next/link';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<header>
				<div
					className='fixed z-20 flex w-screen justify-center
						text-white'
				>
					<MainNav />
				</div>
			</header>
			<main>{children}</main>
			<footer
				className='py-10 px-20 bg-zinc-900 text-white flex flex-col
					space-y-15 text-3xl'
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
