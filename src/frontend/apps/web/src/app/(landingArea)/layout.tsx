import { ReactNode } from 'react';

import Image from 'next/image';
import Link from 'next/link';

import logoSVG from '@/assets/logo.svg';
import {
	NavigationMenu,
	NavigationMenuItem,
	NavigationMenuLink,
	NavigationMenuList,
} from '@repo/ui/components/ui/NavigationMenu';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<header>
				<div className='fixed z-20 text-white'>
					<NavigationMenu className='m-10'>
						<div className='me-30'>
							<Image
								width={30}
								height={30}
								src={logoSVG}
								alt='polyqube logo'
							/>
						</div>
						<NavigationMenuList className='space-x-20'>
							<NavigationMenuItem>
								<NavigationMenuLink asChild>
									<Link href={'#'}>menu 1</Link>
								</NavigationMenuLink>
							</NavigationMenuItem>
							<NavigationMenuItem>
								<NavigationMenuLink asChild>
									<Link href={'#'}>menu 2</Link>
								</NavigationMenuLink>
							</NavigationMenuItem>
							<NavigationMenuItem>
								<NavigationMenuLink asChild>
									<Link href={'#'}>menu 3</Link>
								</NavigationMenuLink>
							</NavigationMenuItem>
						</NavigationMenuList>
					</NavigationMenu>
				</div>
			</header>
			<main>{children}</main>
		</div>
	);
}

export default LandingLayout;
