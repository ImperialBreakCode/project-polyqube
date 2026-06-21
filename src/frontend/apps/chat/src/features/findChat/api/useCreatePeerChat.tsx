'use client';

import { createPeerChatRequest } from '@/server';
import { useAuthWrapper } from '@/shared';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';

function useCreatePeerChat() {
	const { data, error, loading, fetchApi, statusCode } = useAuthWrapper(
		useApi(createPeerChatRequest),
	);

	const createPeerChat = useCallback(
		async (peerProfileId: string) => {
			return await fetchApi({ peerProfileId });
		},
		[fetchApi],
	);

	return {
		createPeerChat,
		chat: data,
		loading,
		error,
		statusCode,
	};
}

export default useCreatePeerChat;
