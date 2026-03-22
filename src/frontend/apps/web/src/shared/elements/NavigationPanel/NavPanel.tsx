import React from 'react';
import PanelNavLink from './PanelNavLink';
import CloseNavPanelButton from './CloseNavPanelButton';
import SmallNavLinksGroup from './SmallNavLinksGroup';
import { ROUTE_PATHS } from '@/shared/constants';

const NavPanel = React.forwardRef<HTMLDivElement>((_, ref) => {
	return (
		<div
			ref={ref}
			className='fixed top-0 left-0 w-full bg-[#181818] h-screen z-100
				text-white'
		>
			<div
				className='mx-5 my-10 lg:my-30 lg:mx-20 flex flex-col
					lg:flex-row justify-between items-center'
			>
				<CloseNavPanelButton
					className='md:hidden flex p-4 text-[0.8rem] mb-10'
				/>
				<p
					className='text-3xl lg:text-5xl font-merriweather mb-7
						lg:mb-0'
				>
					PolyQube
				</p>

				<SmallNavLinksGroup />
			</div>
			<div className='flex flex-col text-2xl md:text-4xl py-10 sm:px-10'>
				<PanelNavLink className='border-t' href={ROUTE_PATHS.home}>
					<span className='text-lg md:text-xl text-gray-300'>
						/01 -{' '}
					</span>
					Home
				</PanelNavLink>
				<PanelNavLink href={ROUTE_PATHS.services}>
					<span className='text-lg md:text-xl text-gray-300'>
						/02 -{' '}
					</span>
					Services
				</PanelNavLink>
				<PanelNavLink href={ROUTE_PATHS.about}>
					<span className='text-lg md:text-xl text-gray-300'>
						/03 -{' '}
					</span>
					About
				</PanelNavLink>
			</div>
		</div>
	);
});

NavPanel.displayName = 'NavPanel';

export default NavPanel;
