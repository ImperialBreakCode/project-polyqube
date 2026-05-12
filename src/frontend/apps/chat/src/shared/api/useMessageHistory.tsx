'use client';

import { MessageHistoryRequestDTO, getMessageHistoryRequest } from '@/server';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';
import { useAuthWrapper } from '../hooks';

function useMessageHistory() {
	const { data, error, loading, fetchApi, statusCode } = useAuthWrapper(
		useApi(getMessageHistoryRequest),
	);

	const getMessageHistory = useCallback(
		async (requestDTO: MessageHistoryRequestDTO) => {
			return await fetchApi(requestDTO);
		},
		[fetchApi],
	);

	return {
		getMessageHistory,
		messages: data ?? [],
		loading,
		error,
		statusCode,
	};
}

export default useMessageHistory;
