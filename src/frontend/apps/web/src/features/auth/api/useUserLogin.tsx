'use client';

//import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
//import { STATUS_CODES } from '@/shared/constants/statusCodes';
import { loginRequest } from '@/server/authRequests';
import { ProblemTypeFormNamePath, useFormApi } from '@/shared/hooks';

const problemTypeMap: ProblemTypeFormNamePath = {
	// [USER_PROBLEM_TYPES.emailAlreadyExists]: {
	// 	fieldName: 'email',
	// },
	// [USER_PROBLEM_TYPES.usernameAlreadyExists]: {
	// 	fieldName: 'username',
	// },
};

function useUserRegister() {
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

export default useUserRegister;
