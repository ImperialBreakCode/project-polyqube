import { createUserDetailsRequest } from '@/server/userRequests';
import { useAuthWrapper } from '@/shared/hooks';
import { ProblemTypeFormNamePath } from '@repo/ui/hooks/api/useApi';
import useFormApi from '@repo/ui/hooks/api/useFormApi';

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
