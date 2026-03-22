'use client';

import { useEffect, useState } from 'react';

function useBreakpoint(minWidth: number) {
	const [isWithin, setIsWithin] = useState<boolean>(false);

	useEffect(() => {
		const mql = window.matchMedia(`(max-width: ${minWidth - 1}px)`);
		const onChange = () => {
			setIsWithin(window.innerWidth >= minWidth);
		};

		mql.addEventListener('change', onChange);

		return () => mql.removeEventListener('change', onChange);
	}, [minWidth]);

	useEffect(() => {
		setIsWithin(window.innerWidth >= minWidth);
	}, [minWidth]);

	return isWithin;
}

export default useBreakpoint;
