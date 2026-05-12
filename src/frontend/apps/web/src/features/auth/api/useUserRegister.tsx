'use client';

import { registerRequest } from '@/server/userRequests';
import { USER_PROBLEM_TYPES } from '@/shared';
import { ProblemTypeFormNamePath } from '@repo/ui/hooks/api/useApi';
import useFormApi from '@repo/ui/hooks/api/useFormApi';

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
