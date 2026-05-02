'use server';
import { STATUS_CODES } from '@/shared/constants/statusCodes';
import { fetchServer, FetchServerOptions } from './fetchServer';
import { getTokenService } from './tokenCookies';
import { FetchServerReturnType } from '@repo/utils/server/baseFetch';

const REFRESH_AUTH_ROUTE = '/api/v1/account/auth/refresh';

type RefreshAuthTokensRequestDTO = {
	refreshToken: string;
};

type RefreshAuthTokensResponseDTO = {
	refreshToken: string;
	accessToken: string;
};

export async function fetchServerWithAuth<Rs = unknown, Rq = unknown>(
	url: string,
	{ headers, ...restOptions }: FetchServerOptions<Rq>,
): Promise<FetchServerReturnType<Rs>> {
	const { getAccessTokenCookie, getRefreshTokenCookie } =
		await getTokenService();

	let accessToken = (await getAccessTokenCookie())?.value;
	let refreshToken = (await getRefreshTokenCookie())?.value;
	let sessionRefreshed = false;
	let tryRefresh = !accessToken;

	if (!refreshToken) {
		return await unauthorized<Rs>();
	}

	while (!sessionRefreshed) {
		if (tryRefresh) {
			const response = await refreshTokenSession(refreshToken);

			if (response.statusCode !== STATUS_CODES.ok || !response.body) {
				return await unauthorized<Rs>();
			}

			accessToken = response.body.accessToken;
			refreshToken = response.body.refreshToken;
			sessionRefreshed = true;
		}

		const response = await fetchServer<Rs, Rq>(url, {
			...restOptions,
			headers: {
				...headers,
				Authorization: accessToken!,
			},
		});

		if (response.statusCode !== STATUS_CODES.unauthorized) {
			return response;
		}

		tryRefresh = true;
	}
	return await unauthorized<Rs>();
}

//
// helpers
async function refreshTokenSession(refreshToken: string) {
	const { setAccessTokenCookie, setRefreshTokenCookie } =
		await getTokenService();

	const refreshResponse = await fetchServer<
		RefreshAuthTokensResponseDTO,
		RefreshAuthTokensRequestDTO
	>(REFRESH_AUTH_ROUTE, {
		method: 'POST',
		body: {
			refreshToken,
		},
	});

	if (
		refreshResponse.statusCode === STATUS_CODES.ok &&
		refreshResponse.body
	) {
		const tokens = refreshResponse.body;
		await setAccessTokenCookie(tokens.accessToken);
		await setRefreshTokenCookie(tokens.refreshToken);
	}

	return refreshResponse;
}

async function unauthorized<T = unknown>(): Promise<FetchServerReturnType<T>> {
	const { tokenSessionCleanup } = await getTokenService();

	await tokenSessionCleanup();
	return {
		statusCode: STATUS_CODES.unauthorized,
	};
}
