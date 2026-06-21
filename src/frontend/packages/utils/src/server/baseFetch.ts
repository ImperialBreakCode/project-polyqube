import {
	ApiServerProblemResponse,
	getServerRoute,
	MethodTypes,
} from './fetchServerApiUtils';

export type BaseFetchServerOptions<T = unknown> = {
	method?: MethodTypes;
	headers?: HeadersInit;
	body: T;
};

export type FetchServerReturnType<T = unknown> = {
	body?: T;
	problemResponse?: ApiServerProblemResponse;
	statusCode?: number;
	error?: string;
};

export async function baseFetchServer<Rs = unknown, Rq = unknown>(
	url: string,
	{ method = 'GET', body, headers, ...rest }: BaseFetchServerOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	try {
		const isFormData = body instanceof FormData;

		const finalHeaders = {
			...headers,
			...(isFormData ? {} : { 'Content-Type': 'application/json' }),
		};

		if (isFormData) {
			delete finalHeaders['Content-Type'];
		}

		const result = await fetch(getServerRoute(url), {
			...rest,
			method,
			body: body
				? isFormData
					? (body as BodyInit)
					: JSON.stringify(body)
				: undefined,
			headers: {
				...headers,
				...(isFormData ? {} : { 'Content-Type': 'application/json' }),
			},
		});

		if (result.ok) {
			const bodyResponse =
				result.status !== 204
					? ((await result.json()) as Rs)
					: (null as Rs);
			return {
				body: bodyResponse,
				statusCode: result.status,
			};
		}

		if (result.status === 403) {
			return {
				statusCode: 403,
			};
		}

		const bodyResponse = (await result.json()) as ApiServerProblemResponse;

		return {
			statusCode: result.status,
			problemResponse: bodyResponse,
		};
	} catch (err) {
		return {
			error: err instanceof Error ? err.message : String(err),
		};
	}
}
