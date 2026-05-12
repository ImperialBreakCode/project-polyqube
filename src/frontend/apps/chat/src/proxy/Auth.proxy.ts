import { NextRequest, NextResponse } from 'next/server';
import { getTokenService } from '@/server/base/tokenCookies';
import BaseProxy from './Base.proxy';
import UtilsConfig from '@repo/utils/utilConfig/UtilsConfig';

class AuthProxy extends BaseProxy {
	protected include: string[] = ['*'];
	protected exclude: string[] = ['/login'];

	protected async execute(
		_request: NextRequest,
	): Promise<NextResponse<unknown> | undefined | void> {
		const { getRefreshTokenCookie } = await getTokenService();
		const refreshTokenCookie = await getRefreshTokenCookie();

		if (!refreshTokenCookie) {
			const url = new URL('service-login', UtilsConfig.webAppHost);

			return NextResponse.redirect(url);
		}
	}
}

export default AuthProxy;
