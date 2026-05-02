'use server';

import { cookies } from 'next/headers';
import { createTokenService } from '@repo/utils/server/tokenCookies';

export async function getTokenService() {
	const cookieStore = await cookies();

	return createTokenService(cookieStore);
}
