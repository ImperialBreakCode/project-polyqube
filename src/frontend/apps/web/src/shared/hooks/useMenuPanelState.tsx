'use client';

import { useAppSelector } from '@/redux';
import { selectMenuPanel } from '@/shared/actions';

function useMenuPanelState() {
	const isMenuOpen = useAppSelector(selectMenuPanel);

	return { isMenuOpen };
}

export default useMenuPanelState;
