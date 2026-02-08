'use client';

import { useIsMediumScreen } from '@/shared/hooks';
import CloseNavPanelButton from './CloseNavPanelButton';
import PanelNavLinkSmall from './PanelNavLinkSmall';

const SmallNavLinksGroup = () => {
	const isMediumScreen = useIsMediumScreen();

	return (
		<div className='space-x-5 flex'>
			<PanelNavLinkSmall href={'#'}>Login</PanelNavLinkSmall>
			<PanelNavLinkSmall href={'#'}>Register</PanelNavLinkSmall>
			{isMediumScreen && <CloseNavPanelButton />}
		</div>
	);
};

export default SmallNavLinksGroup;
