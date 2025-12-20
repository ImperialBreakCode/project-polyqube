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
		<NavigationMenu className='m-10'>
			<div className='me-30'>
				<Image
					width={30}
					height={30}
					src={logoSVG}
					alt='polyqube logo'
				/>
			</div>
			<NavigationMenuList className='space-x-15'>
				<NavigationMenuItem>
					<MainNavLink href={'#'}>Menu 1</MainNavLink>
				</NavigationMenuItem>
				<NavigationMenuItem>
					<MainNavLink href={'#'}>Menu 2</MainNavLink>
				</NavigationMenuItem>
				<NavigationMenuItem>
					<MainNavLink href={'#'}>Menu 3</MainNavLink>
				</NavigationMenuItem>
			</NavigationMenuList>
		</NavigationMenu>
	);
};

export default MainNav;
