'use server';

import { getTokenService } from './base/tokenCookies';

export async function getSignalRAccessToken(): Promise<{
	token: string | null;
}> {
	const { getAccessTokenCookie } = await getTokenService();
	const token = (await getAccessTokenCookie())?.value ?? null;
	return { token };
}

export async function getChatHost() {
	return 'http://localhost:8050';
}
