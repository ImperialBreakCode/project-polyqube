'use client';

import { getCurrentUserRequest } from '@/server';
import { useCallback } from 'react';
import useApi from '@repo/ui/hooks/api/useApi';

function useCurrentProfile(fetchOnInit: boolean = true) {
	const { data, error, loading, fetchApi } = useApi(getCurrentUserRequest, {
		initRequestData: null,
		requestOnInit: fetchOnInit,
	});

	const getCurrentProfile = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		getCurrentProfile,
		currentProfile: data,
		loading,
		error,
	};
}

export default useCurrentProfile;
