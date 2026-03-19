'use client';

import { setProfilePictureRequest } from '@/server/userRequests';
import { useApi } from '../hooks';

function useSetProfilePicture() {
	const { fetchApi, loading, statusCode, error } = useApi(
		setProfilePictureRequest,
	);

	return {
		setProfilePicture: fetchApi,
		loading,
		statusCode,
		error,
	};
}

export default useSetProfilePicture;
