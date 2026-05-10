'use client';

import { CHAT_EVENTS } from '@/shared/constants';
import { getCurrentProfileChatsRequest } from '@/server';
import { useCallback, useEffect } from 'react';
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

	useEffect(() => {
		const handleChatCreated = async () => {
			await getCurrentProfileChats();
		};

		window.addEventListener(CHAT_EVENTS.chatCreated, handleChatCreated);

		return () => {
			window.removeEventListener(CHAT_EVENTS.chatCreated, handleChatCreated);
		};
	}, [getCurrentProfileChats]);

	return {
		getCurrentProfileChats,
		chats: data ?? [],
		loading,
		error,
	};
}

export default useCurrentProfileChats;
