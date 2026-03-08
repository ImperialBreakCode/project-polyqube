'use client';

import { useCallback, useEffect, useState } from 'react';
import { ServerRequestReturnType } from '@/server/base/serverRequest';

type UseApiOptions<Rq = unknown> = {
	initRequestData?: Rq;
	requestOnInit?: boolean;
};

function useApi<Rs = unknown, Rq = unknown>(
	createRequestFunc: () => ServerRequestReturnType<Rs, Rq>,
	options?: UseApiOptions<Rq>,
) {
	const { fetchApi, data, error, problemDetails } = createRequestFunc();

	const [loading, setLoading] = useState<boolean>(false);
	const [apiDataState, setApiDataState] = useState<
		Omit<ServerRequestReturnType<Rs, Rq>, 'fetchApi'>
	>({
		data,
		error,
		problemDetails,
	});

	const fetchApiCall = useCallback(
		async (fetchBody: Rq) => {
			setLoading(true);
			const response = await fetchApi(fetchBody);

			if (response.error) {
				console.error(response.error);
			}

			setApiDataState({
				data: response.body,
				error: response.error,
				problemDetails: response.problemResponse,
			});
			setLoading(false);
		},
		[fetchApi],
	);

	useEffect(() => {
		const initRequestCall = async () => {
			if (options?.initRequestData && options?.requestOnInit) {
				await fetchApiCall(options?.initRequestData);
			}
		};

		initRequestCall();
	});

	return {
		data: apiDataState.data,
		loading,
		problemDetails: apiDataState.problemDetails,
		error: apiDataState.error,
		fetchApi: fetchApiCall,
	};
}

export default useApi;
