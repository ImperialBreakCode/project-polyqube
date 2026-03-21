'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ROUTE_PATHS, STATUS_CODES } from '../constants';

function useAuthWrapper<T extends { statusCode?: number }>(returnVals: T): T {
	const router = useRouter();

	useEffect(() => {
		if (returnVals.statusCode === STATUS_CODES.unauthorized) {
			router.push(ROUTE_PATHS.auth.login);
		}
	}, [router, returnVals.statusCode]);

	return returnVals;
}

export default useAuthWrapper;
