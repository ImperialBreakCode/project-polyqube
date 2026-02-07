'use client';

import { useMenuPanelState } from '@/shared/hooks';
import NavPanel from './NavPanel';
import { useEffect } from 'react';

const NavPanelWrapper = () => {
	const { isMenuOpen } = useMenuPanelState();

	useEffect(() => {
		document.body.classList.toggle('lock-scroll', isMenuOpen);
		return () => document.body.classList.remove('lock-scroll');
	}, [isMenuOpen]);

	return <>{isMenuOpen && <NavPanel />}</>;
};

export default NavPanelWrapper;
