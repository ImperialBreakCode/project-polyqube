'use server';
import { cookies } from 'next/headers';
import AppError from '@repo/utils/errors/AppError';
import {
	extractAccessTokenClaims,
	extractRefreshTokenClaims,
	getTokenMaxAge,
} from '@/shared/utils/tokenUtils';
import { COOKIE_NAMES } from '@/shared';

async function setCookieToken(token: string, exp: number, cookieName: string) {
	const maxAge = getTokenMaxAge(exp);

	if (maxAge === 0) {
		throw new AppError('Token expired');
	}

	const cookieStore = await cookies();
	cookieStore.set({
		name: cookieName,
		value: token,
		httpOnly: true,
		path: '/',
		maxAge,
	});
}

export async function getTokenCookie(tokenName: string) {
	const cookieStore = await cookies();
	return cookieStore.get(tokenName);
}

export async function deleteTokenCookie(tokenName: string) {
	const cookieStore = await cookies();
	return cookieStore.delete(tokenName);
}

export async function setRefreshTokenCookie(token: string) {
	const claims = extractRefreshTokenClaims(token);
	await setCookieToken(token, claims.exp, COOKIE_NAMES.refreshToken);
}

export async function setAccessTokenCookie(token: string) {
	const claims = extractAccessTokenClaims(token);
	await setCookieToken(token, claims.exp, COOKIE_NAMES.accessToken);
}

export const getRefreshTokenCookie = async () =>
	await getTokenCookie(COOKIE_NAMES.refreshToken);

export const getAccessTokenCookie = async () =>
	await getTokenCookie(COOKIE_NAMES.accessToken);

export const deleteRefreshTokenCookie = async () =>
	await deleteTokenCookie(COOKIE_NAMES.refreshToken);

export const deleteAccessTokenCookie = async () =>
	await deleteTokenCookie(COOKIE_NAMES.accessToken);

export const tokenSessionCleanup = async () => {
	await deleteAccessTokenCookie();
	await deleteRefreshTokenCookie();
};
