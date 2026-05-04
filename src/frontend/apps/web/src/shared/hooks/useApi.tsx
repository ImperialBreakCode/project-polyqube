'use client';

import { useCallback, useEffect, useMemo, useState } from 'react';
import { AppFormError } from '@repo/ui/components/AppForm/AppForm';
import { ApiServerProblemResponse } from '@repo/utils/server/fetchServerApiUtils';
import { FetchServerReturnType } from '@repo/utils/server/baseFetch';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

type UseApiOptions<Rq = unknown> = {
	initRequestData?: Rq;
	requestOnInit?: boolean;
};

export type ProblemTypeFormNamePath = Record<
	string,
	{
		fieldName: string;
		errorMessage?: string;
	}
>;

function uncapitalize(str: string): string {
	if (!str) return str;
	return str.charAt(0).toLowerCase() + str.slice(1);
}

export function getFormErrorsFromProblemDetails(
	problemTypeMap: ProblemTypeFormNamePath,
	problemDetails: ApiServerProblemResponse,
): AppFormError[] {
	const errorInfo = problemTypeMap[problemDetails.type];
	if (!errorInfo) {
		return [];
	}

	const formError: AppFormError = {
		fieldName: errorInfo.fieldName,
		errorMessage: errorInfo.errorMessage ?? problemDetails.detail,
	};

	return [formError];
}

export function getProblemFormMessage(
	problemDetails?: ApiServerProblemResponse,
	map?: ProblemTypeFormNamePath,
) {
	if (!problemDetails) {
		return null;
	}

	if (map && map[problemDetails.type]) {
		return null;
	}

	if (
		problemDetails.status === STATUS_CODES.unprocessableContent ||
		problemDetails.status === STATUS_CODES.unsupportedMediaType
	) {
		return null;
	}

	return problemDetails.detail;
}

function useApi<Rs = unknown, Rq = unknown>(
	request: (body: Rq) => Promise<FetchServerReturnType<Rs>>,
	options?: UseApiOptions<Rq>,
) {
	const [loading, setLoading] = useState<boolean>(false);
	const [apiDataState, setApiDataState] = useState<FetchServerReturnType<Rs>>(
		{},
	);

	const validationErrors = useMemo(() => {
		if (!apiDataState.problemResponse?.errors) {
			return [];
		}

		const errors: AppFormError[] = [];

		const entries = Object.entries(apiDataState.problemResponse.errors);
		for (const [key, value] of entries) {
			if (value[0]) {
				errors.push({
					fieldName: uncapitalize(key),
					errorMessage: value[0],
				});
			}
		}

		return errors;
	}, [apiDataState.problemResponse]);

	const fetchApi = useCallback(
		async (fetchBody: Rq) => {
			setLoading(true);
			const response = await request(fetchBody);

			if (response.error) {
				console.error(response.error);
			}

			setApiDataState(response);
			setLoading(false);

			return { statusCode: response.statusCode };
		},
		[request],
	);

	useEffect(() => {
		const initRequestCall = async () => {
			if (options?.requestOnInit) {
				await fetchApi(options?.initRequestData as Rq);
			}
		};

		initRequestCall();
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	return {
		data: apiDataState.body,
		loading,
		problemDetails: apiDataState.problemResponse,
		validationErrors,
		error: apiDataState.error,
		fetchApi,
		statusCode: apiDataState.statusCode,
	};
}

export default useApi;

export type UseApiReturnType<Rs = unknown, Rq = unknown> = ReturnType<
	typeof useApi<Rs, Rq>
>;
