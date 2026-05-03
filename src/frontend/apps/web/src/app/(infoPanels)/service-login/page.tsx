'use client';

import { useRequestModuleLogin } from '@/features/auth';
import { AppButton, ROUTE_PATHS } from '@/shared';
import {
	Card,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';
import { Link } from 'lucide-react';

function ServiceLoginPage() {
	const { code, loading } = useRequestModuleLogin('chat-service');

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
