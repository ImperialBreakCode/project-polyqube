'use client';

import { useMemo } from 'react';
//import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
//import { STATUS_CODES } from '@/shared/constants/statusCodes';
import { loginRequest } from '@/server/authRequests';
import {
	getFormErrorsFromProblemDetails,
	getProblemFormMessage,
	ProblemTypeFormNamePath,
	useApi,
} from '@/shared/hooks';

const problemTypeMap: ProblemTypeFormNamePath = {
	// [USER_PROBLEM_TYPES.emailAlreadyExists]: {
	// 	fieldName: 'email',
	// },
	// [USER_PROBLEM_TYPES.usernameAlreadyExists]: {
	// 	fieldName: 'username',
	// },
};

function useUserRegister() {
	const { fetchApi, loading, problemDetails, error, validationErrors } =
		useApi(loginRequest);

	const loginFormErrors = useMemo(() => {
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
		login: fetchApi,
		loading,
		errorMessage: errorMessage ?? problemMessage,
		loginFormErrors,
	};
}

export default useUserRegister;
