'use client';

import useBreakpoint from './useBreakpoint';

function useIsMediumScreen() {
	return useBreakpoint(768);
}

export default useIsMediumScreen;
