'use client';

import {
	GetChatParticipantsRequestDTO,
	getChatParticipantsRequest,
} from '@/server';
import useApi from '@repo/ui/hooks/api/useApi';
import { useCallback } from 'react';
import { useAuthWrapper } from '../hooks';

function useChatParticipants() {
	const { data, error, loading, fetchApi, statusCode } = useAuthWrapper(
		useApi(getChatParticipantsRequest),
	);

	const getChatParticipants = useCallback(
		async (chatId: string, requestDTO: GetChatParticipantsRequestDTO) => {
			return await fetchApi({ chatId, requestDTO });
		},
		[fetchApi],
	);

	return {
		getChatParticipants,
		participants: data ?? [],
		loading,
		error,
		statusCode,
	};
}

export default useChatParticipants;
