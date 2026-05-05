'use server';

import { CHAT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

export type ChatResponseDTO = {
	id: string;
	chatName: string | null;
	isGroupChat: boolean;
	aiEnabled: boolean;
};

export async function getCurrentProfileChatsRequest() {
	return await serverRequest<ChatResponseDTO[], null>(
		`${CHAT_SERVICE_ROUTE}/chats/get-current-profile-chats`,
		{
			method: 'GET',
			requestWithAuth: true,
			body: null,
		},
	);
}
