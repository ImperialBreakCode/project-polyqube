'use client';

import { useMenuPanelState } from '@/shared/hooks';
import NavPanel from './NavPanel';

const NavPanelWrapper = () => {
	const { isMenuOpen } = useMenuPanelState();

	return <>{isMenuOpen && <NavPanel />}</>;
};

export default NavPanelWrapper;
