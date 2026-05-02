import { NextRequest, NextResponse } from 'next/server';
import { getTokenService } from '@/server/base';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import BaseProxy from './Base.proxy';

class GuestProxy extends BaseProxy {
	protected include: string[] = ['/auth'];
	protected exclude: string[] = [];

	protected async execute(
		request: NextRequest,
	): Promise<NextResponse<unknown> | undefined | void> {
		const { getRefreshTokenCookie } = await getTokenService();
		const refreshTokenCookie = await getRefreshTokenCookie();

		if (refreshTokenCookie) {
			return NextResponse.redirect(
				new URL(ROUTE_PATHS.userPanel.homeDashboard, request.url),
			);
		}
	}
}

export default GuestProxy;
