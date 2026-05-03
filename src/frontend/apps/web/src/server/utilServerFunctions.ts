'use server';

import UtilsConfig from '@repo/utils/utilConfig/UtilsConfig';
import { getTokenService } from './base';

export async function checkForRefreshToken() {
	const { getRefreshTokenCookie } = await getTokenService();

	const refreshToken = await getRefreshTokenCookie();
	return !!refreshToken;
}

export async function getAppHosts() {
	return { chatHost: UtilsConfig.chatAppHost };
}
