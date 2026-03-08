'use client';

import { registerRequest } from '@/server/userRequests';
import useApi from '@/shared/hooks/useApi';

function useUserRegister() {
	const { fetchApi, loading, problemDetails, error } =
		useApi(registerRequest);

	const errorMessage = error ? 'Error occured. Please try again.' : undefined;

	return {
		register: fetchApi,
		loading,
		errorMessage: errorMessage ?? problemDetails?.detail,
	};
}

export default useUserRegister;
