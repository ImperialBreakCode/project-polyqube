'use client';

import { useCallback } from 'react';
import useCreatePeerChat from './useCreatePeerChat';
import useGetPeerChat from './useGetPeerChat';

function usePeerChat() {
	const getPeerChatHook = useGetPeerChat();
	const createPeerChatHook = useCreatePeerChat();
	const { getPeerChat: fetchPeerChat, chat: peerChat } = getPeerChatHook;
	const { createPeerChat: postPeerChat, chat: createdPeerChat } =
		createPeerChatHook;

	const getPeerChat = useCallback(
		async (peerProfileId: string) => {
			const response = await fetchPeerChat(peerProfileId);
			return {
				statusCode: response.statusCode,
				chat: peerChat,
			};
		},
		[fetchPeerChat, peerChat],
	);

	const createPeerChat = useCallback(
		async (peerProfileId: string) => {
			const response = await postPeerChat(peerProfileId);
			return {
				statusCode: response.statusCode,
				chat: createdPeerChat,
			};
		},
		[postPeerChat, createdPeerChat],
	);

	return {
		getPeerChat,
		createPeerChat,
		loading: getPeerChatHook.loading || createPeerChatHook.loading,
		peerChat,
		createdPeerChat,
	};
}

export default usePeerChat;
