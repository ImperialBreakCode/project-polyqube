import { NextRequest, NextResponse } from 'next/server';
import { getTokenService } from '@/server/base/tokenCookies';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import { URL_QUERY_KEYS } from '@/shared/constants/urlQueryKeys';
import BaseProxy from './Base.proxy';

class AuthProxy extends BaseProxy {
	protected include: string[] = ['/user-panel', '/setup'];
	protected exclude: string[] = [];

	protected async execute(
		request: NextRequest,
	): Promise<NextResponse<unknown> | undefined | void> {
		const { getRefreshTokenCookie } = await getTokenService();
		const refreshTokenCookie = await getRefreshTokenCookie();

		if (!refreshTokenCookie) {
			const url = new URL(ROUTE_PATHS.auth.login, request.url);
			url.searchParams.append(
				URL_QUERY_KEYS.callbackUrl,
				request.nextUrl.pathname,
			);

			return NextResponse.redirect(url);
		}
	}
}

export default AuthProxy;
