import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';
import AuthProxy from './proxy/Auth.proxy';

const proxies = [new AuthProxy()];

export async function proxy(request: NextRequest) {
	for (const proxy of proxies) {
		const result = await proxy.run(request);

		if (result) {
			return result;
		}
	}

	return NextResponse.next();
}
