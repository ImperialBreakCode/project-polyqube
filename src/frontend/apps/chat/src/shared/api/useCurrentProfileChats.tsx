'use client';

import { getCurrentProfileChatsRequest } from '@/server';
import { useCallback } from 'react';
import useApi from '@repo/ui/hooks/api/useApi';
import { useAuthWrapper } from '../hooks';

function useCurrentProfileChats(fetchOnInit: boolean = true) {
	const { data, error, loading, fetchApi } = useAuthWrapper(
		useApi(getCurrentProfileChatsRequest, {
			initRequestData: null,
			requestOnInit: fetchOnInit,
		}),
	);

	const getCurrentProfileChats = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		getCurrentProfileChats,
		chats: data ?? [],
		loading,
		error,
	};
}

export default useCurrentProfileChats;
