'use client';

import { getPeerChatRequest } from '@/server';
import { useAuthWrapper } from '@/shared';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';

function useGetPeerChat() {
	const { data, error, loading, fetchApi, statusCode } = useAuthWrapper(
		useApi(getPeerChatRequest),
	);

	const getPeerChat = useCallback(
		async (peerProfileId: string) => {
			return await fetchApi(peerProfileId);
		},
		[fetchApi],
	);

	return {
		getPeerChat,
		chat: data,
		loading,
		error,
		statusCode,
	};
}

export default useGetPeerChat;
