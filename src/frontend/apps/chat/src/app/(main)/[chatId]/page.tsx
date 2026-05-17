'use client';

import { ChatFeature } from '@/features';
import { useChatRoom } from '@/features/chat';
import {
	useCurrentProfileChats,
	useUpdateChatSettings,
} from '@/shared';
import { useParams } from 'next/navigation';
import { useState } from 'react';

function ChatPage() {
	const { chatId } = useParams<{ chatId: string }>();
	const { chats, getCurrentProfileChats } = useCurrentProfileChats();
	const { updateChatSettings, loading: updatingChatSettings } =
		useUpdateChatSettings();
	const {
		firstParticipant,
		hubReady,
		mappedMessages,
		notifyTyping,
		peerIsTyping,
		sendMessage,
	} = useChatRoom(chatId);

	const currentChat = chats.find((chat) => chat.id === chatId);
	const [isSettingsDialogOpen, setIsSettingsDialogOpen] = useState(false);
	const [aiEnabled, setAiEnabled] = useState(false);

	const handleOpenSettings = () => {
		setAiEnabled(currentChat?.aiEnabled ?? false);
		setIsSettingsDialogOpen(true);
	};

	const handleSaveSettings = async () => {
		if (!chatId) {
			return;
		}
		await updateChatSettings({ chatId, aiEnabled });
		await getCurrentProfileChats();
		setIsSettingsDialogOpen(false);
	};

	return (
		<div className='h-screen flex flex-col'>
			<ChatFeature.ChatHeader
				participant={firstParticipant}
				onOpenSettings={handleOpenSettings}
			/>
			<ChatFeature.ChatMessages
				messages={mappedMessages}
				peerIsTyping={peerIsTyping}
			/>
			<ChatFeature.ChatComposer
				aiEnabled={Boolean(currentChat?.aiEnabled)}
				sendDisabled={!hubReady}
				onSend={sendMessage}
				onTyping={notifyTyping}
			/>
			<ChatFeature.ChatSettingsDialog
				isOpen={isSettingsDialogOpen}
				aiEnabled={aiEnabled}
				loading={updatingChatSettings}
				chatId={chatId}
				onOpenChange={setIsSettingsDialogOpen}
				onAiEnabledChange={setAiEnabled}
				onSave={handleSaveSettings}
			/>
		</div>
	);
}

export default ChatPage;
