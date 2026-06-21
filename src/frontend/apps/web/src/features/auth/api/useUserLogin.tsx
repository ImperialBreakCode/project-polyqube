'use client';

import { loginRequest } from '@/server/authRequests';
import { AUTH_PROBLEM_TYPES } from '@/shared/constants/serverProblemTypes';
import { ProblemTypeFormNamePath } from '@repo/ui/hooks/api/useApi';
import useFormApi from '@repo/ui/hooks/api/useFormApi';

const problemTypeMap: ProblemTypeFormNamePath = {
	[AUTH_PROBLEM_TYPES.invalidUsernameException]: {
		fieldName: 'username',
	},
	[AUTH_PROBLEM_TYPES.invalidPasswordException]: {
		fieldName: 'password',
	},
};

function useUserLogin() {
	const { fetchApi, loading, errorMessage, formErrors } = useFormApi(
		loginRequest,
		{ problemTypeMap },
	);

	return {
		login: fetchApi,
		loading,
		errorMessage,
		loginFormErrors: formErrors,
	};
}

export default useUserLogin;
