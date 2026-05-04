'use client';

import { createChatProfile } from '@/server';
import { useAuthWrapper } from '@/shared';
import useApi from '@repo/ui/hooks/api/useApi';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';
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
