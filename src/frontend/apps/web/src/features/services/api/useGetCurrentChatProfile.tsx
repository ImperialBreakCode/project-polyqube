'use client';

import { getCurrentChatProfile } from '@/server';
import { STATUS_CODES, useApi, useAuthWrapper } from '@/shared';

function useGetCurrentChatProfile() {
	const { loading, statusCode, data } = useAuthWrapper(
		useApi(getCurrentChatProfile, {
			requestOnInit: true,
		}),
	);

	return {
		loading,
		success: statusCode === STATUS_CODES.ok,
		chatProfile: data,
	};
}

export default useGetCurrentChatProfile;
