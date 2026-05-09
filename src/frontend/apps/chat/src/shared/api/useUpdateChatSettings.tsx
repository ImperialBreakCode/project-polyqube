'use client';

import { UpdateChatSettingsRequestDTO, updateChatSettingsRequest } from '@/server';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';
import { useAuthWrapper } from '../hooks';

function useUpdateChatSettings() {
	const { data, error, loading, fetchApi, statusCode } = useAuthWrapper(
		useApi(updateChatSettingsRequest),
	);

	const updateChatSettings = useCallback(
		async (requestDTO: UpdateChatSettingsRequestDTO) => {
			return await fetchApi(requestDTO);
		},
		[fetchApi],
	);

	return {
		updateChatSettings,
		result: data,
		loading,
		error,
		statusCode,
	};
}

export default useUpdateChatSettings;
