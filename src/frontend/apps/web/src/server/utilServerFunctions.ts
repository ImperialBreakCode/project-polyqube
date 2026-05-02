'use server';

import { getTokenService } from './base';

export async function checkForRefreshToken() {
	const { getRefreshTokenCookie } = await getTokenService();

	const refreshToken = await getRefreshTokenCookie();
	return !!refreshToken;
}
