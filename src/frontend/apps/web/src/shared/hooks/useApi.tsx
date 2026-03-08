'use client';

import { FetchServerReturnType } from '@/server/base';
import { useCallback, useEffect, useState } from 'react';

type UseApiOptions<Rq = unknown> = {
	initRequestData?: Rq;
	requestOnInit?: boolean;
};

function useApi<Rs = unknown, Rq = unknown>(
	request: (body: Rq) => Promise<FetchServerReturnType<Rs>>,
	options?: UseApiOptions<Rq>,
) {
	const [loading, setLoading] = useState<boolean>(false);
	const [apiDataState, setApiDataState] = useState<FetchServerReturnType<Rs>>(
		{},
	);

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
		error: apiDataState.error,
		fetchApi,
	};
}

export default useApi;
