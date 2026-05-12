import { STATUS_CODES } from '../constants/statusCodes';
import {
	baseFetchServer,
	BaseFetchServerOptions,
	FetchServerReturnType,
} from './baseFetch';
import {
	createTokenService,
	CookieStore,
	CreateTokenServiceReturnType,
} from './tokenCookies';

const REFRESH_AUTH_ROUTE = '/api/v1/account/auth/refresh';

type RefreshAuthTokensRequestDTO = {
	refreshToken: string;
};

type RefreshAuthTokensResponseDTO = {
	refreshToken: string;
	accessToken: string;
};

export async function baseFetchServerWithAuth<Rs = unknown, Rq = unknown>(
	url: string,
	{ headers, ...restOptions }: BaseFetchServerOptions<Rq>,
	cookieStore: CookieStore,
): Promise<FetchServerReturnType<Rs>> {
	const tokenService = createTokenService(cookieStore);

	const { getAccessTokenCookie, getRefreshTokenCookie } = tokenService;

	let accessToken = (await getAccessTokenCookie())?.value;
	let refreshToken = (await getRefreshTokenCookie())?.value;
	let sessionRefreshed = false;
	let tryRefresh = !accessToken;

	if (!refreshToken) {
		return await unauthorized<Rs>(tokenService);
	}

	while (!sessionRefreshed) {
		if (tryRefresh) {
			const response = await refreshTokenSession(
				refreshToken,
				tokenService,
			);

			if (response.statusCode !== STATUS_CODES.ok || !response.body) {
				return await unauthorized<Rs>(tokenService);
			}

			accessToken = response.body.accessToken;
			refreshToken = response.body.refreshToken;
			sessionRefreshed = true;
		}

		const response = await baseFetchServer<Rs, Rq>(url, {
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
	return await unauthorized<Rs>(tokenService);
}

//
// helpers
async function refreshTokenSession(
	refreshToken: string,
	tokenService: CreateTokenServiceReturnType,
) {
	const { setAccessTokenCookie, setRefreshTokenCookie } = tokenService;

	const refreshResponse = await baseFetchServer<
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

async function unauthorized<T = unknown>(
	tokenService: CreateTokenServiceReturnType,
): Promise<FetchServerReturnType<T>> {
	const { tokenSessionCleanup } = tokenService;

	await tokenSessionCleanup();
	return {
		statusCode: STATUS_CODES.unauthorized,
	};
}
