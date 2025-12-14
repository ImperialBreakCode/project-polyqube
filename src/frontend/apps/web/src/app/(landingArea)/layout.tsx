import Image from 'next/image';
import { ReactNode } from 'react';
import logoSVG from '@/assets/logo.svg';
import Link from 'next/link';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<header>
				<div className='fixed z-20 text-white'>
					<nav className='m-10 flex flex-row justify-center'>
						<div className='me-30'>
							<Image
								width={30}
								height={30}
								src={logoSVG}
								alt='polyqube logo'
							/>
						</div>
						<div>
							<ul className='flex h-full flex-row justify-center space-x-20'>
								<li>
									<Link href={'#'}>menu 1</Link>
								</li>
								<li>
									<Link href={'#'}>menu 2</Link>
								</li>
								<li>
									<Link href={'#'}>menu 3</Link>
								</li>
							</ul>
						</div>
					</nav>
				</div>
			</header>
			<main>{children}</main>
		</div>
	);
}

export default LandingLayout;
