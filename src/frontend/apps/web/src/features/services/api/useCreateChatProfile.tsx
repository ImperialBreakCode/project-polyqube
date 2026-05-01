'use client';

import { createChatProfile } from '@/server';
import { STATUS_CODES, useApi, useAuthWrapper } from '@/shared';
import { useCallback } from 'react';

function useCreateChatProfile() {
	const { loading, statusCode, fetchApi } = useAuthWrapper(
		useApi(createChatProfile),
	);

	const createProfile = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		loading,
		success: statusCode === STATUS_CODES.created,
		createProfile,
	};
}

export default useCreateChatProfile;
