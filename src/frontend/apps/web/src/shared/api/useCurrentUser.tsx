'use client';

import { getCurrentUserRequest } from '@/server';
import { useApi, useAuthWrapper } from '../hooks';
import { useCallback } from 'react';

function useCurrentUser(fetchOnInit: boolean = true) {
	const { data, error, problemDetails, loading, fetchApi } = useAuthWrapper(
		useApi(getCurrentUserRequest, {
			initRequestData: null,
			requestOnInit: fetchOnInit,
		}),
	);

	const getCurrentUser = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		getCurrentUser,
		currentUser: data,
		loading,
		error,
		problemDetails,
	};
}

export default useCurrentUser;
