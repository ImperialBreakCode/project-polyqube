'use server';
import { FetchServerOptions } from './fetchServer';

import { FetchServerReturnType } from '@repo/utils/server/baseFetch';
import { baseFetchServerWithAuth } from '@repo/utils/server/fetchServerWithAuth';
import { cookies } from 'next/headers';

export async function fetchServerWithAuth<Rs = unknown, Rq = unknown>(
	url: string,
	options: FetchServerOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	const cookiesStore = await cookies();
	return await baseFetchServerWithAuth(url, options, cookiesStore);
}
