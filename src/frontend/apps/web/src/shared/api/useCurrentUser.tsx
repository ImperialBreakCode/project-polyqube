'use client';

import { getCurrentUserRequest } from '@/server';
import { useAuthWrapper } from '../hooks';
import { useCallback } from 'react';
import useApi from '@repo/ui/hooks/api/useApi';

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
