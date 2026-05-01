'use client';

import { getCurrentChatProfile } from '@/server';
import { STATUS_CODES, useApi, useAuthWrapper } from '@/shared';
import { useCallback } from 'react';

function useGetCurrentChatProfile() {
	const { loading, statusCode, data, fetchApi } = useAuthWrapper(
		useApi(getCurrentChatProfile, {
			requestOnInit: true,
		}),
	);

	const refetchProfile = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		loading,
		success: statusCode === STATUS_CODES.ok,
		chatProfile: data,
		refetchProfile,
	};
}

export default useGetCurrentChatProfile;
