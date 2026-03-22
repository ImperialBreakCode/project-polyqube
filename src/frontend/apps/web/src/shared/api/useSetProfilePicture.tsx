'use client';

import { setProfilePictureRequest } from '@/server/userRequests';
import { useApi, useAuthWrapper } from '../hooks';

function useSetProfilePicture() {
	const { fetchApi, loading, statusCode, error } = useAuthWrapper(
		useApi(setProfilePictureRequest),
	);

	return {
		setProfilePicture: fetchApi,
		loading,
		statusCode,
		error,
	};
}

export default useSetProfilePicture;
