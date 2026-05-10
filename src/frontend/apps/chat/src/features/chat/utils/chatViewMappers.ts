import type {
	ChatHistoryMessageApiModel,
	ChatMessageViewModel,
	ChatParticipantApiModel,
	MessageParticipant,
} from '../types';

type BuildMappedMessagesOptions = {
	historyMessages: ChatHistoryMessageApiModel[];
	participants: MessageParticipant[];
	currentProfileId?: string;
};

export function mapMessageParticipants(
	participants: ChatParticipantApiModel[],
): MessageParticipant[] {
	return participants.map((participant) => {
		const profileName = participant.userProfile?.fullName ?? null;
		const agentName = participant.chatAgent?.agentName ?? null;
		const displayName = participant.chatNickname ?? profileName ?? agentName ?? '';

		return {
			id: participant.id,
			displayName,
			userProfileId: participant.userProfile?.id ?? null,
			profilePicture:
				participant.userProfile?.profilePicture ??
				participant.chatAgent?.profilePicture ??
				null,
			isBot: Boolean(participant.chatAgent),
		};
	});
}

export function getPrimaryParticipant(
	participants: MessageParticipant[],
	currentProfileId?: string,
) {
	return (
		participants.find((participant) => participant.userProfileId !== currentProfileId) ??
		participants[0]
	);
}

export function buildMappedMessages({
	historyMessages,
	participants,
	currentProfileId,
}: BuildMappedMessagesOptions): ChatMessageViewModel[] {
	const participantsById = new Map(participants.map((participant) => [participant.id, participant]));

	return historyMessages.map((message, index) => {
		const participant = message.participantId
			? participantsById.get(message.participantId)
			: undefined;
		const name = participant?.displayName ?? 'Unknown';
		const initials = name.slice(0, 2).toUpperCase();
		const isCurrentUser = Boolean(
			participant?.userProfileId &&
				currentProfileId &&
				participant.userProfileId === currentProfileId,
		);
		const isBot = participant?.isBot ?? message.messageType === 1;

		return {
			id: `${message.participantId ?? 'none'}-${index}`,
			name,
			initials,
			side: isCurrentUser ? 'right' : 'left',
			text: message.textContent,
			profilePicture: participant?.profilePicture ?? '...',
			isBot,
		};
	});
}
