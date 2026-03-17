'use client';

import { setProfilePictureRequest } from '@/server/userRequests';
import { useApi } from '../hooks';

function useSetProfilePicture() {
	const { fetchApi, loading, statusCode } = useApi(setProfilePictureRequest);

	return {
		setProfilePicture: fetchApi,
		loading,
		statusCode,
	};
}

export default useSetProfilePicture;
