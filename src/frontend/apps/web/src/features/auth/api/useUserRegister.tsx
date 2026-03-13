'use client';

import { useMemo } from 'react';
import { registerRequest } from '@/server/userRequests';
import useApi, {
	getFormErrorsFromProblemDetails,
	getProblemFormMessage,
	ProblemTypeFormNamePath,
} from '@/shared/hooks/useApi';
import { USER_PROBLEM_TYPES } from '@/shared';

const problemTypeMap: ProblemTypeFormNamePath = {
	[USER_PROBLEM_TYPES.emailAlreadyExists]: {
		fieldName: 'email',
	},

	[USER_PROBLEM_TYPES.usernameAlreadyExists]: {
		fieldName: 'username',
	},
};

function useUserRegister() {
	const { fetchApi, loading, problemDetails, error, validationErrors } =
		useApi(registerRequest);

	const registerFormErrors = useMemo(() => {
		if (validationErrors.length !== 0 || !problemDetails) {
			return validationErrors;
		}

		return getFormErrorsFromProblemDetails(problemTypeMap, problemDetails);
	}, [validationErrors, problemDetails]);

	const errorMessage = error ? 'Error occured. Please try again.' : undefined;
	const problemMessage = getProblemFormMessage(
		problemDetails,
		problemTypeMap,
	);

	return {
		register: fetchApi,
		loading,
		errorMessage: errorMessage ?? problemMessage,
		registerFormErrors,
	};
}

export default useUserRegister;
