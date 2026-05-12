'use client';

import { useCallback } from 'react';
import { logoutRequest } from '@/server/authRequests';
import useApi from '@repo/ui/hooks/api/useApi';

function useLogout() {
	const { fetchApi, error, loading } = useApi(logoutRequest);

	const logout = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		logout,
		error,
		logoutLoading: loading,
	};
}

export default useLogout;
