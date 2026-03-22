'use client';

import { useCallback, useContext } from 'react';
import { useIsMediumScreen, useMenuPanelActions } from '@/shared/hooks';
import CloseNavPanelButton from './CloseNavPanelButton';
import PanelNavLinkSmall from './PanelNavLinkSmall';
import { ROUTE_PATHS } from '@/shared/constants';
import { SessionContext } from '@/shared/contexts';
import { useLogout } from '@/shared/api';

const SmallNavLinksGroup = () => {
	const isMediumScreen = useIsMediumScreen();
	const { state, updateSession } = useContext(SessionContext);
	const { logout } = useLogout();
	const { closeMenu } = useMenuPanelActions();

	const onLogout = useCallback(async () => {
		await logout();
		await updateSession();
		closeMenu();
	}, [logout, updateSession, closeMenu]);

	return (
		<div className='space-x-5 flex'>
			{state.authState === 'guest' ? (
				<>
					<PanelNavLinkSmall href={ROUTE_PATHS.auth.login}>
						Login
					</PanelNavLinkSmall>
					<PanelNavLinkSmall href={ROUTE_PATHS.auth.register}>
						Register
					</PanelNavLinkSmall>
				</>
			) : (
				<>
					<PanelNavLinkSmall isButton onBtnClick={onLogout}>
						Logout
					</PanelNavLinkSmall>
					<PanelNavLinkSmall
						href={ROUTE_PATHS.userPanel.homeDashboard}
					>
						User Panel
					</PanelNavLinkSmall>
				</>
			)}

			{isMediumScreen && <CloseNavPanelButton />}
		</div>
	);
};

export default SmallNavLinksGroup;
