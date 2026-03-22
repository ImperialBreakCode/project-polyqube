'use client';

import useBreakpoint from './useBreakpoint';

function useIsLargeScreen() {
	return useBreakpoint(1024);
}

export default useIsLargeScreen;
