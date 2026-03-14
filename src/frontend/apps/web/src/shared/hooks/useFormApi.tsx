'use client';

import { useMemo } from 'react';
import { FetchServerReturnType } from '@/server/base';
import useApi, {
	getFormErrorsFromProblemDetails,
	getProblemFormMessage,
	ProblemTypeFormNamePath,
} from './useApi';

function useFormApi<Rs = unknown, Rq = unknown>(
	request: (body: Rq) => Promise<FetchServerReturnType<Rs>>,
	{
		problemTypeMap,
	}: {
		problemTypeMap: ProblemTypeFormNamePath;
	},
) {
	const { fetchApi, loading, problemDetails, error, validationErrors } =
		useApi(request);

	const formErrors = useMemo(() => {
		if (validationErrors.length !== 0 || !problemDetails) {
			return validationErrors;
		}

		return getFormErrorsFromProblemDetails(problemTypeMap, problemDetails);
	}, [validationErrors, problemDetails, problemTypeMap]);

	const errorMessage = error ? 'Error occured. Please try again.' : undefined;
	const problemMessage = getProblemFormMessage(
		problemDetails,
		problemTypeMap,
	);

	return {
		fetchApi,
		loading,
		errorMessage: errorMessage ?? problemMessage,
		formErrors,
	};
}

export default useFormApi;
