'use server';

import { CHAT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

export type ChatResponseDTO = {
	id: string;
	chatName: string | null;
	isGroupChat: boolean;
	aiEnabled: boolean;
};

export type ParticipantUserProfileResponseDTO = {
	id: string;
	fullName: string;
	profilePicture: string | null;
	createdAt: string;
	updatedAt: string;
};

export type ParticipantChatAgentResponseDTO = {
	id: string;
	agentName: string;
	agentUsername: string;
	profilePicture: string | null;
	createdAt: string;
	updatedAt: string;
};

export type ParticipantResponseDTO = {
	id: string;
	chatNickname: string | null;
	userProfile: ParticipantUserProfileResponseDTO | null;
	chatAgent: ParticipantChatAgentResponseDTO | null;
	createdAt: string;
	updatedAt: string;
};

export type CreatePeerChatRequestDTO = {
	peerProfileId: string;
};

export type GetChatParticipantsRequestDTO = {
	participantCount?: number;
	includeAgents: boolean;
};

export type UpdateChatSettingsRequestDTO = {
	chatId: string;
	aiEnabled?: boolean | null;
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

export async function getPeerChatRequest(peerProfileId: string) {
	return await serverRequest<ChatResponseDTO, null>(
		`${CHAT_SERVICE_ROUTE}/chats/peer-chat/${peerProfileId}`,
		{
			method: 'GET',
			requestWithAuth: true,
			body: null,
		},
	);
}

export async function createPeerChatRequest(requestDTO: CreatePeerChatRequestDTO) {
	return await serverRequest<ChatResponseDTO, CreatePeerChatRequestDTO>(
		`${CHAT_SERVICE_ROUTE}/chats/create-peer-chat`,
		{
			method: 'POST',
			requestWithAuth: true,
			body: requestDTO,
		},
	);
}

export async function getChatParticipantsRequest({
	chatId,
	requestDTO,
}: {
	chatId: string;
	requestDTO: GetChatParticipantsRequestDTO;
}) {
	const searchParams = new URLSearchParams({
		includeAgents: String(requestDTO.includeAgents),
	});

	if (requestDTO.participantCount !== undefined) {
		searchParams.set('participantCount', String(requestDTO.participantCount));
	}

	return await serverRequest<ParticipantResponseDTO[], null>(
		`${CHAT_SERVICE_ROUTE}/chats/${chatId}/participants?${searchParams.toString()}`,
		{
			method: 'GET',
			requestWithAuth: true,
			body: null,
		},
	);
}

export async function updateChatSettingsRequest(
	requestDTO: UpdateChatSettingsRequestDTO,
) {
	return await serverRequest<null, UpdateChatSettingsRequestDTO>(
		`${CHAT_SERVICE_ROUTE}/chats/update-chat-settings`,
		{
			method: 'PUT',
			requestWithAuth: true,
			body: requestDTO,
		},
	);
}
