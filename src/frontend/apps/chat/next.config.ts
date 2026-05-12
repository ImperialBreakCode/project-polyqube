import type { NextConfig } from 'next';
import path from 'path';

/** Must match server-side `API_BASE_HOST` so client + SignalR can use same-origin `/api/*` (no browser CORS). */
const apiBaseHost = process.env.API_BASE_HOST ?? 'http://localhost:8040';

const nextConfig: NextConfig = {
	turbopack: {
		root: path.join(__dirname, '..', '..'),
	},
	experimental: {
		serverActions: {
			bodySizeLimit: '10mb',
		},
	},
	async rewrites() {
		return [
			{
				source: '/api/:path*',
				destination: `${apiBaseHost}/api/:path*`,
			},
		];
	},
};

export default nextConfig;
