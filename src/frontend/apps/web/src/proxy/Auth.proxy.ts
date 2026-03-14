import { NextRequest, NextResponse } from 'next/server';
import { getRefreshTokenCookie } from '@/server/base/tokenCookies';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import BaseProxy from './Base.proxy';

class AuthProxy extends BaseProxy {
	protected include: string[] = ['/user-panel'];
	protected exclude: string[] = [];

	protected async execute(
		request: NextRequest,
	): Promise<NextResponse<unknown> | undefined | void> {
		const refreshTokenCookie = await getRefreshTokenCookie();

		if (!refreshTokenCookie) {
			return NextResponse.redirect(
				new URL(ROUTE_PATHS.auth.login, request.url),
			);
		}
	}
}

export default AuthProxy;
