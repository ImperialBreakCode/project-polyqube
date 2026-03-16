import Image from 'next/image';

import { NavigationMenuItem, NavigationMenuList } from '@repo/ui/core';
import { ROUTE_PATHS } from '@/shared/constants';

import MainNavLink from './MainNavLink';
import MainNavMenuWrapper from './MainNavMenuWrapper';

import logoSVG from '@/assets/logo.svg';
import MainNavRightSide from './MainNavRightSide';

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
						<MainNavLink href={ROUTE_PATHS.home}>Home</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={ROUTE_PATHS.services}>
							Services
						</MainNavLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<MainNavLink href={ROUTE_PATHS.about}>
							About
						</MainNavLink>
					</NavigationMenuItem>

					<MainNavRightSide />
				</NavigationMenuList>
			</div>
		</MainNavMenuWrapper>
	);
};

export default MainNav;
