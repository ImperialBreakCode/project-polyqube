'use client';

import { useEffect } from 'react';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

function useAuthWrapper<T extends { statusCode?: number }>(returnVals: T): T {
	useEffect(() => {
		if (
			returnVals.statusCode === STATUS_CODES.unauthorized ||
			returnVals.statusCode === 403
		) {
			window.location.href = 'http://localhost:3000/service-login';
		}
	}, [returnVals.statusCode]);

	return returnVals;
}

export default useAuthWrapper;
