'use client';

import Image from 'next/image';

import { NavigationMenuItem, NavigationMenuList } from '@repo/ui/core';
import MainNavLink from './MainNavLink';
import MainNavMenuWrapper from './MainNavMenuWrapper';

import logoSVG from '@/assets/logo.svg';

const MainNav = () => {
	return (
		<MainNavMenuWrapper>
			<div className='ms-5 me-10'>
				<Image
					width={20}
					height={20}
					src={logoSVG}
					alt='polyqube logo'
				/>
			</div>
			<div className='w-full'>
				<NavigationMenuList className='space-x-3'>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>Home</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>Services</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>About</MainNavLink>
					</NavigationMenuItem>

					<NavigationMenuItem className='ms-auto'>
						<MainNavLink href={'#'}>Login</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink
							className='bg-linear-to-r from-[#f1deff]
								to-[#c2d7ff] font-semibold text-black
								hover:from-[#e8c9ff] hover:to-[#bad2ff]'
							href={'#'}
						>
							Join
						</MainNavLink>
					</NavigationMenuItem>
				</NavigationMenuList>
			</div>
		</MainNavMenuWrapper>
	);
};

export default MainNav;
