import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';
import AuthProxy from './proxy/Auth.proxy';
import GuestProxy from './proxy/Guest.proxy';

const proxies = [new AuthProxy(), new GuestProxy()];

export async function proxy(request: NextRequest) {
	// Server Actions and their CORS preflight requests should not be redirected
	// by app-level auth guards, otherwise browser preflight fails on redirects.
	if (
		request.method === 'OPTIONS' ||
		request.headers.has('next-action')
	) {
		return NextResponse.next();
	}

	for (const proxy of proxies) {
		const result = await proxy.run(request);

		if (result) {
			return result;
		}
	}

	return NextResponse.next();
}
