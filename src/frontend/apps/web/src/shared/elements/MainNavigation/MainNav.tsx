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
		<NavigationMenu className='m-10 w-[70vw] justify-between rounded-full bg-[#68686892] p-5'>
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
						<MainNavLink href={'#'}>Menu 1</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>Menu 2</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>Menu 3</MainNavLink>
					</NavigationMenuItem>

					<NavigationMenuItem className='ms-auto'>
						<MainNavLink href={'#'}>Login</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={'#'}>Join</MainNavLink>
					</NavigationMenuItem>
				</NavigationMenuList>
			</div>
		</NavigationMenu>
	);
};

export default MainNav;
