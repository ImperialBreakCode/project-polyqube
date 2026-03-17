import { createUserDetailsRequest } from '@/server/userRequests';
import { ProblemTypeFormNamePath, useFormApi } from '@/shared/hooks';

const problemTypeMap: ProblemTypeFormNamePath = {};

function useCreateUserDetails() {
	const { fetchApi, errorMessage, formErrors, loading } = useFormApi(
		createUserDetailsRequest,
		{ problemTypeMap },
	);

	return {
		createUserDetails: fetchApi,
		loading,
		errorMessage,
		formErrors: formErrors,
	};
}

export default useCreateUserDetails;
