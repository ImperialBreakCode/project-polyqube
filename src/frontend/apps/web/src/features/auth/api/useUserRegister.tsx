'use client';

import { registerRequest } from '@/server/userRequests';
import useApi from '@/shared/hooks/useApi';

function useUserRegister() {
	const { fetchApi, loading, problemDetails } = useApi(registerRequest);

	return {
		register: fetchApi,
		loading,
		problemMessage: problemDetails?.detail,
	};
}

export default useUserRegister;
