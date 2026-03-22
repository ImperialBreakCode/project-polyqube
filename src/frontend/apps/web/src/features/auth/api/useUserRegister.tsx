'use client';

import { registerRequest } from '@/server/userRequests';
import { ProblemTypeFormNamePath } from '@/shared/hooks/useApi';
import { useFormApi, USER_PROBLEM_TYPES } from '@/shared';

const problemTypeMap: ProblemTypeFormNamePath = {
	[USER_PROBLEM_TYPES.emailAlreadyExists]: {
		fieldName: 'email',
	},

	[USER_PROBLEM_TYPES.usernameAlreadyExists]: {
		fieldName: 'username',
	},
};

function useUserRegister() {
	const { fetchApi, loading, errorMessage, formErrors } = useFormApi(
		registerRequest,
		{ problemTypeMap },
	);

	return {
		register: fetchApi,
		loading,
		errorMessage,
		registerFormErrors: formErrors,
	};
}

export default useUserRegister;
