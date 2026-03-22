import { createUserDetailsRequest } from '@/server/userRequests';
import {
	ProblemTypeFormNamePath,
	useAuthWrapper,
	useFormApi,
} from '@/shared/hooks';

const problemTypeMap: ProblemTypeFormNamePath = {};

function useCreateUserDetails() {
	const { fetchApi, errorMessage, formErrors, loading } = useAuthWrapper(
		useFormApi(createUserDetailsRequest, { problemTypeMap }),
	);

	return {
		createUserDetails: fetchApi,
		loading,
		errorMessage,
		formErrors: formErrors,
	};
}

export default useCreateUserDetails;
