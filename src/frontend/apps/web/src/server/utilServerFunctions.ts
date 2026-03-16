'use server';

import { getRefreshTokenCookie } from './base';

export async function checkForRefreshToken() {
	const refreshToken = await getRefreshTokenCookie();
	return !!refreshToken;
}
