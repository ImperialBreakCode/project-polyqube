import type { NextConfig } from 'next';
import path from 'path';

const nextConfig: NextConfig = {
	turbopack: {
		root: path.join(__dirname, '..', '..'),
	},
	experimental: {
		serverActions: {
			bodySizeLimit: '10mb',
		},
	},
};

export default nextConfig;
