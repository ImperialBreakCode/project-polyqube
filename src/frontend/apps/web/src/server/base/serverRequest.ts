'use server';

import { UrlInput } from '@repo/utils/server/fetchServerApiUtils';
import {
	fetchServer,
	FetchServerOptions,
	FetchServerReturnType,
} from './fetchServer';
import { fetchServerWithAuth } from './fetchServerWithAuth';

type ServerRequestOptions<T = unknown> = FetchServerOptions<T> & {
	requestWithAuth?: boolean;
	requestOnInit?: boolean;
};

export async function serverRequest<Rs = unknown, Rq = unknown>(
	url: UrlInput,
	{
		requestOnInit,
		requestWithAuth = true,
		body,
		...rest
	}: ServerRequestOptions<Rq>,
) {
	const fetchFunc = requestWithAuth
		? fetchServerWithAuth<Rs, Rq>
		: fetchServer<Rs, Rq>;

	const fetchApi = async (fetchBody?: Rq) =>
		await fetchFunc(url, { body: fetchBody, ...rest });

	let response: FetchServerReturnType<Rs> | null = null;

	if (requestOnInit) {
		response = await fetchApi(body);
	}

	const error = {};

	return {
		data: response?.body,
		error,
		problemDetails: response?.problemResponse,
		fetchApi,
	};
}
