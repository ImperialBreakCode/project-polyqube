import { NextRequest, NextResponse } from 'next/server';

abstract class BaseProxy {
	protected abstract include: string[];
	protected abstract exclude: string[];

	protected abstract execute(
		request: NextRequest,
	): Promise<NextResponse<unknown> | undefined | void>;

	public async run(request: NextRequest) {
		const pathname = request.nextUrl.pathname;

		if (this.exclude.some((x) => pathname.startsWith(x))) {
			return;
		}

		if (this.include.some((x) => x === '*' || pathname.startsWith(x))) {
			return await this.execute(request);
		}
	}
}

export default BaseProxy;
