'use client';

import { searchProfilesRequest } from '@/server';
import { useAuthWrapper } from '@/shared';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';

function useProfileSearch() {
	const { data, loading, error, fetchApi } = useAuthWrapper(
		useApi(searchProfilesRequest),
	);

	const searchProfiles = useCallback(
		async (searchTerm: string) => {
			return await fetchApi(searchTerm);
		},
		[fetchApi],
	);

	return {
		profiles: data ?? [],
		loading,
		error,
		searchProfiles,
	};
}

export default useProfileSearch;
