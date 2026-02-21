'use client';

import { useIsMediumScreen } from '@/shared/hooks';
import CloseNavPanelButton from './CloseNavPanelButton';
import PanelNavLinkSmall from './PanelNavLinkSmall';
import { ROUTE_PATHS } from '@/shared/constants';

const SmallNavLinksGroup = () => {
	const isMediumScreen = useIsMediumScreen();

	return (
		<div className='space-x-5 flex'>
			<PanelNavLinkSmall href={ROUTE_PATHS.auth.login}>
				Login
			</PanelNavLinkSmall>
			<PanelNavLinkSmall href={ROUTE_PATHS.auth.register}>
				Register
			</PanelNavLinkSmall>
			{isMediumScreen && <CloseNavPanelButton />}
		</div>
	);
};

export default SmallNavLinksGroup;
