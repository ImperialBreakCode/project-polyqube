'use server';

import { FetchServerReturnType } from '@repo/utils/server/baseFetch';
import { fetchServer, FetchServerOptions } from './fetchServer';
import { fetchServerWithAuth } from './fetchServerWithAuth';

type ServerRequestOptions<T = unknown> = FetchServerOptions<T> & {
	requestWithAuth?: boolean;
};

export async function serverRequest<Rs = unknown, Rq = unknown>(
	url: string,
	{ requestWithAuth = true, ...rest }: ServerRequestOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	const fetchFunc = requestWithAuth
		? fetchServerWithAuth<Rs, Rq>
		: fetchServer<Rs, Rq>;

	return await fetchFunc(url, rest);
}
