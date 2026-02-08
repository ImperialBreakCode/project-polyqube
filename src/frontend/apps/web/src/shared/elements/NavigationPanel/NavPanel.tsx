import React from 'react';
import PanelNavLink from './PanelNavLink';
import PanelNavLinkSmall from './PanelNavLinkSmall';
import CloseNavPanelButton from './CloseNavPanelButton';

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

				<div className='md:space-x-5 flex'>
					<PanelNavLinkSmall href={'#'}>Login</PanelNavLinkSmall>
					<PanelNavLinkSmall href={'#'}>Register</PanelNavLinkSmall>
					<CloseNavPanelButton className='hidden md:flex' />
				</div>
			</div>
			<div className='flex flex-col text-2xl md:text-4xl py-10 sm:px-10'>
				<PanelNavLink className='border-t' href={'#'}>
					<span className='text-lg md:text-xl text-gray-300'>
						/01 -{' '}
					</span>
					Home
				</PanelNavLink>
				<PanelNavLink href={'#'}>
					<span className='text-lg md:text-xl text-gray-300'>
						/02 -{' '}
					</span>
					About
				</PanelNavLink>
				<PanelNavLink href={'#'}>
					<span className='text-lg md:text-xl text-gray-300'>
						/03 -{' '}
					</span>
					Services
				</PanelNavLink>
			</div>
		</div>
	);
});

NavPanel.displayName = 'NavPanel';

export default NavPanel;
