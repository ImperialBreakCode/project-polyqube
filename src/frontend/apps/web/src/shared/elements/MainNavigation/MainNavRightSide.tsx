'use client';

import { useCallback, useContext } from 'react';
import { Button, NavigationMenuItem } from '@repo/ui/core';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import { SessionContext } from '@/shared/contexts';
import { useLogout } from '@/shared/api';
import MainNavLink from './MainNavLink';

function MainNavRightSide() {
	const { state, updateSession } = useContext(SessionContext);
	const { logout } = useLogout();

	const onLogout = useCallback(async () => {
		await logout();
		await updateSession();
	}, [logout, updateSession]);

	return state.authState === 'guest' ? (
		<>
			<NavigationMenuItem className='ms-auto'>
				<MainNavLink href={ROUTE_PATHS.auth.login}>Login</MainNavLink>
			</NavigationMenuItem>
			<NavigationMenuItem>
				<MainNavLink
					className='bg-linear-to-r from-[#f1deff] to-[#c2d7ff]
						font-semibold text-black hover:from-[#e8c9ff]
						hover:to-[#bad2ff]'
					href={ROUTE_PATHS.auth.register}
				>
					Join
				</MainNavLink>
			</NavigationMenuItem>
		</>
	) : (
		<>
			<NavigationMenuItem className='ms-auto'>
				<MainNavLink
					className='bg-linear-to-r from-[#f1deff] to-[#c2d7ff]
						font-semibold text-black hover:from-[#e8c9ff]
						hover:to-[#bad2ff]'
					href={ROUTE_PATHS.userPanel.homeDashboard}
				>
					User Panel
				</MainNavLink>
			</NavigationMenuItem>
			<NavigationMenuItem>
				<Button
					onClick={onLogout}
					className='rounded-full bg-transparent text-white px-4 py-2
						cursor-pointer text-[0.9rem] transition duration-200
						hover:bg-gray-200 hover:text-black h-[33.33px]'
				>
					Logout
				</Button>
			</NavigationMenuItem>
		</>
	);
}

export default MainNavRightSide;
