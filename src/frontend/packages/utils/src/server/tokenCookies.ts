import { COOKIE_NAMES } from '../constants';
import { AppError } from '../errors';
import {
	extractAccessTokenClaims,
	extractRefreshTokenClaims,
	getTokenMaxAge,
} from '../utilFuncs';

interface CookieStore {
	get(name: string): { value: string } | undefined;
	set(options: {
		name: string;
		value: string;
		httpOnly?: boolean;
		path?: string;
		maxAge?: number;
	}): void;
	delete(name: string): void;
}

export function createTokenService(cookieStore: CookieStore) {
	async function setCookieToken(
		token: string,
		exp: number,
		cookieName: string,
	) {
		const maxAge = getTokenMaxAge(exp);

		if (maxAge === 0) {
			throw new AppError('Token expired');
		}

		cookieStore.set({
			name: cookieName,
			value: token,
			httpOnly: true,
			path: '/',
			maxAge,
		});
	}

	async function getTokenCookie(tokenName: string) {
		return cookieStore.get(tokenName);
	}

	async function deleteTokenCookie(tokenName: string) {
		return cookieStore.delete(tokenName);
	}

	async function setRefreshTokenCookie(token: string) {
		const claims = extractRefreshTokenClaims(token);
		await setCookieToken(token, claims.exp, COOKIE_NAMES.refreshToken);
	}

	async function setAccessTokenCookie(token: string) {
		const claims = extractAccessTokenClaims(token);
		await setCookieToken(token, claims.exp, COOKIE_NAMES.accessToken);
	}

	const getRefreshTokenCookie = async () =>
		await getTokenCookie(COOKIE_NAMES.refreshToken);

	const getAccessTokenCookie = async () =>
		await getTokenCookie(COOKIE_NAMES.accessToken);

	const deleteRefreshTokenCookie = async () =>
		await deleteTokenCookie(COOKIE_NAMES.refreshToken);

	const deleteAccessTokenCookie = async () =>
		await deleteTokenCookie(COOKIE_NAMES.accessToken);

	const tokenSessionCleanup = async () => {
		await deleteAccessTokenCookie();
		await deleteRefreshTokenCookie();
	};

	return {
		getTokenCookie,
		deleteTokenCookie,
		setRefreshTokenCookie,
		setAccessTokenCookie,
		getRefreshTokenCookie,
		getAccessTokenCookie,
		deleteRefreshTokenCookie,
		deleteAccessTokenCookie,
		tokenSessionCleanup,
	};
}
