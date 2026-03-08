'use server';
import {
	UrlInput,
	MethodTypes,
	getServerRoute,
	ApiServerProblemResponse,
} from '@repo/utils/server/fetchServerApiUtils';

export type FetchServerOptions<T = unknown> = {
	method?: MethodTypes;
	cache?: RequestCache;
	next?: NextFetchRequestConfig;
	headers?: HeadersInit;
	body?: T;
};

export type FetchServerReturnType<T = unknown> = {
	body?: T;
	problemResponse?: ApiServerProblemResponse;
	statusCode?: number;
	error?: string;
};

export async function fetchServer<Rs = unknown, Rq = unknown>(
	url: UrlInput,
	{ method = 'GET', body, ...rest }: FetchServerOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	try {
		const result = await fetch(getServerRoute(url), {
			...rest,
			method,
			body: body ? JSON.stringify(body) : undefined,
		});

		if (result.ok) {
			const bodyResponse = (await result.json()) as Rs;
			return {
				body: bodyResponse,
				statusCode: result.status,
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
