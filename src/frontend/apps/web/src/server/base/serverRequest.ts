'use server';

import {
	ApiServerProblemResponse,
	UrlInput,
} from '@repo/utils/server/fetchServerApiUtils';
import {
	fetchServer,
	FetchServerOptions,
	FetchServerReturnType,
} from './fetchServer';
import { fetchServerWithAuth } from './fetchServerWithAuth';

type ServerRequestOptions<T = unknown> = FetchServerOptions<T> & {
	requestWithAuth?: boolean;
};

export type ServerRequestReturnType<Rs = unknown, Rq = unknown> = {
	data?: Rs;
	error?: string;
	problemDetails?: ApiServerProblemResponse;
	fetchApi: (fetchBody?: Rq) => Promise<FetchServerReturnType<Rs>>;
};

export function serverRequest<Rs = unknown, Rq = unknown>(
	url: UrlInput,
	{ requestWithAuth = true, ...rest }: Omit<ServerRequestOptions<Rq>, 'body'>,
): ServerRequestReturnType<Rs, Rq> {
	const fetchFunc = requestWithAuth
		? fetchServerWithAuth<Rs, Rq>
		: fetchServer<Rs, Rq>;

	const fetchApi = async (fetchBody?: Rq) =>
		await fetchFunc(url, { body: fetchBody, ...rest });

	return { fetchApi };
}
