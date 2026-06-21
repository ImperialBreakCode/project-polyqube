'use server';

import {
	baseFetchServer,
	BaseFetchServerOptions,
	FetchServerReturnType,
} from '@repo/utils/server/baseFetch';

export type FetchServerOptions<T = unknown> = BaseFetchServerOptions<T> & {
	cache?: RequestCache;
	next?: NextFetchRequestConfig;
};

export async function fetchServer<Rs = unknown, Rq = unknown>(
	url: string,
	options: FetchServerOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	return baseFetchServer<Rs, Rq>(url, options);
}
