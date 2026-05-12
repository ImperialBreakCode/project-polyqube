'use client';

import { setProfilePictureRequest } from '@/server/userRequests';
import { useAuthWrapper } from '../hooks';
import useApi from '@repo/ui/hooks/api/useApi';

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
