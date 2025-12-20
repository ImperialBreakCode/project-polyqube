import { ReactNode } from 'react';
import { MainNav } from '@/shared';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<header>
				<div className='fixed z-20 text-white'>
					<MainNav />
				</div>
			</header>
			<main>{children}</main>
		</div>
	);
}

export default LandingLayout;
