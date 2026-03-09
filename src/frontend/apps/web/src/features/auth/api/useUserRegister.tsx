'use client';

import { registerRequest } from '@/server/userRequests';
import useApi, { getProblemFormMessage } from '@/shared/hooks/useApi';

function useUserRegister() {
	const { fetchApi, loading, problemDetails, error, validationErrors } =
		useApi(registerRequest);

	const errorMessage = error ? 'Error occured. Please try again.' : undefined;
	const problemMessage = getProblemFormMessage(problemDetails);

	return {
		register: fetchApi,
		loading,
		errorMessage: errorMessage ?? problemMessage,
		validationErrors,
	};
}

export default useUserRegister;
