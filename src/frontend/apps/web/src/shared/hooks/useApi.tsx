'use client';

import { useCallback, useEffect, useMemo, useState } from 'react';
import { FetchServerReturnType } from '@/server/base';
import { AppFormError } from '@repo/ui/components/AppForm/AppForm';
import { ApiServerProblemResponse } from '@repo/utils/server/fetchServerApiUtils';
import { STATUS_CODES } from '../constants';

type UseApiOptions<Rq = unknown> = {
	initRequestData?: Rq;
	requestOnInit?: boolean;
};

function uncapitalize(str: string): string {
	if (!str) return str;
	return str.charAt(0).toLowerCase() + str.slice(1);
}

export function getProblemFormMessage(
	problemDetails?: ApiServerProblemResponse,
) {
	if (!problemDetails) {
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
		},
		[request],
	);

	useEffect(() => {
		const initRequestCall = async () => {
			if (options?.initRequestData && options?.requestOnInit) {
				await fetchApi(options?.initRequestData);
			}
		};

		initRequestCall();
	});

	return {
		data: apiDataState.body,
		loading,
		problemDetails: apiDataState.problemResponse,
		validationErrors,
		error: apiDataState.error,
		fetchApi,
	};
}

export default useApi;
