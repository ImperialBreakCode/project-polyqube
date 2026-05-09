'use server';

import { CHAT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

export type MessageResponseDTO = {
	textContent: string;
	messageType: number;
	participantId: string | null;
	chatId: string;
};

export type MessageHistoryRequestDTO = {
	chatId: string;
	count: number;
	offset: number;
};

export async function getMessageHistoryRequest(requestDTO: MessageHistoryRequestDTO) {
	const searchParams = new URLSearchParams({
		chatId: requestDTO.chatId,
		count: String(requestDTO.count),
		offset: String(requestDTO.offset),
	});

	return await serverRequest<MessageResponseDTO[], null>(
		`${CHAT_SERVICE_ROUTE}/messages/message-history?${searchParams.toString()}`,
		{
			method: 'GET',
			requestWithAuth: true,
			body: null,
		},
	);
}
