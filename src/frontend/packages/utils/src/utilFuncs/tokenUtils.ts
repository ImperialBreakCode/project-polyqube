import { decodeJwt } from 'jose';
import AppError from '@repo/utils/errors/AppError';

export type RefreshTokenClaims = {
	exp: number;
};

export type AccessTokenClaims = {
	exp: number;
	roles: string[];
};

export const extractRefreshTokenClaims = (
	refreshToken: string,
): RefreshTokenClaims => {
	const payload = decodeJwt(refreshToken);
	requireClaims(payload, ['exp']);

	return { exp: payload.exp! };
};

export const extractAccessTokenClaims = (
	accessToken: string,
): AccessTokenClaims => {
	const payload = decodeJwt(accessToken);

	requireClaims(payload, ['roles', 'exp']);
	const claims = payload as AccessTokenClaims;

	return { exp: claims.exp, roles: claims.roles };
};

export const getTokenMaxAge = (exp: number) => {
	const now = Math.floor(Date.now() / 1000);
	const maxAge = exp - now;

	return maxAge > 0 ? maxAge : 0;
};

//
// helpers
function requireClaims<T extends object>(payload: T, keys: (keyof T)[]) {
	for (const key of keys) {
		if (!(key in payload)) {
			throw new AppError(`Missing claim: ${String(key)}`);
		}
	}
}
