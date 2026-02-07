'use client';

import { useCallback } from 'react';
import { useAppDispatch } from '@/redux';
import { closeNavMenu, openNavMenu, toggleNavMenu } from '@/shared/actions';

function useMenuPanelActions() {
	const dispatch = useAppDispatch();

	const openMenu = useCallback(() => {
		dispatch(openNavMenu());
	}, [dispatch]);

	const closeMenu = useCallback(() => {
		dispatch(closeNavMenu());
	}, [dispatch]);

	const toggleMenu = useCallback(() => {
		dispatch(toggleNavMenu());
	}, [dispatch]);

	return { openMenu, closeMenu, toggleMenu };
}

export default useMenuPanelActions;
