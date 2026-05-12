'use client';

import { useCallback } from 'react';
import { getCurrentUserRequest } from '@/server/userRequests';
import { SessionContextValues, SessionState } from '../contexts';
import useApi from '@repo/ui/hooks/api/useApi';

function useSessionState(): SessionContextValues {
	const { data, fetchApi } = useApi(getCurrentUserRequest, {
		initRequestData: null,
		requestOnInit: true,
	});

	const state: SessionState = {
		authState: !data
			? 'guest'
			: !data.userDetails
				? 'forSetup'
				: data.userDetails.profilePicturePath
					? 'loggedIn'
					: 'loggedInSetProfPicAccess',
	};

	const updateSession = useCallback(async () => {
		await fetchApi(null);
	}, [fetchApi]);

	return {
		state,
		updateSession,
	};
}

export default useSessionState;
