import Image from 'next/image';

import {
	NavigationMenu,
	NavigationMenuItem,
	NavigationMenuList,
} from '@repo/ui/core';

import logoSVG from '@/assets/logo.svg';
import MainNavLink from './MainNavLink';

const MainNav = () => {
	return (
		<NavigationMenu className='m-10 w-[70vw] justify-between rounded-full bg-[#5050508e] p-5 backdrop-blur-lg'>
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
							className='bg-[#dcdcdc] font-medium text-black'
							href={'#'}
						>
							Join
						</MainNavLink>
					</NavigationMenuItem>
				</NavigationMenuList>
			</div>
		</NavigationMenu>
	);
};

export default MainNav;
