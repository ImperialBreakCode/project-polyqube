/**
 * Client-side models for API payloads used by mappers.
 * Kept in the feature (not `@/shared`) so hooks/DTOs stay decoupled from mapper utilities.
 */
export type ChatParticipantApiModel = {
	id: string;
	chatNickname: string | null;
	userProfile: {
		id: string;
		fullName: string;
		profilePicture: string | null;
	} | null;
	chatAgent: {
		agentName: string;
		profilePicture: string | null;
	} | null;
};

export type ChatHistoryMessageApiModel = {
	id: string;
	textContent: string;
	messageType: number;
	participantId: string | null;
	chatId?: string;
	createdAt: string;
};

export type MessageParticipant = {
	id: string;
	displayName: string;
	userProfileId: string | null;
	profilePicture: string | null;
	isBot: boolean;
};

export type ChatMessageViewModel = {
	id: string;
	name: string;
	initials: string;
	side: 'left' | 'right';
	text: string;
	profilePicture: string;
	isBot: boolean;
};
