'use client';

import { useRequestModuleLogin } from '@/features/auth';
import { getAppHosts } from '@/server';
import { AppButton, ROUTE_PATHS } from '@/shared';
import {
	Card,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';
import { SHARED_URL_QUERY_KEYS } from '@repo/utils/constants/sharedUrlQueryKeys';
import Link from 'next/link';
import { useEffect } from 'react';

function ServiceLoginPage() {
	const { code, loading } = useRequestModuleLogin('chat-service');

	useEffect(() => {
		const redirectToChatApp = async (code: string) => {
			const { chatHost } = await getAppHosts();

			const url = new URL('/login', chatHost);
			url.searchParams.set(SHARED_URL_QUERY_KEYS.code, code);

			window.location.href = url.toString();
		};

		if (code) {
			redirectToChatApp(code);
		}
	}, [code]);

	return (
		<Card className='dark:bg-[#171717] rounded-xl'>
			<CardHeader>
				<CardTitle>
					{loading && 'Please wait...'}
					{!loading && !code && 'No Access to Module'}
				</CardTitle>
				{!loading && !code && (
					<CardDescription>
						You have no access to this module. Please enable the
						service and create service account in the user
						dashboard.
					</CardDescription>
				)}
			</CardHeader>
			<CardFooter className='flex-col items-stretch'>
				<AppButton asChild>
					<Link href={ROUTE_PATHS.userPanel.services}>
						Go to the Services Panel
					</Link>
				</AppButton>
			</CardFooter>
		</Card>
	);
}

export default ServiceLoginPage;
