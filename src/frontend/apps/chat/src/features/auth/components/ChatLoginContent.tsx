'use client';

import { ROUTE_PATHS } from '@/shared';
import { Button } from '@repo/ui/components/ui/Button';
import {
	Card,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/components/ui/Card';
import { SHARED_URL_QUERY_KEYS } from '@repo/utils/constants/sharedUrlQueryKeys';
import Link from 'next/link';
import { useRouter, useSearchParams } from 'next/navigation';
import { useChatLogin } from '../api';
import { useEffect } from 'react';

function ChatLoginContent() {
	const router = useRouter();
	const searchParams = useSearchParams();
	const code = searchParams.get(SHARED_URL_QUERY_KEYS.code);

	const { loading, success } = useChatLogin(code ?? '');

	useEffect(() => {
		if (success) {
			router.push(ROUTE_PATHS.home);
		}
	}, [success, router]);

	return (
		<Card className='dark:bg-[#171717] rounded-xl'>
			<CardHeader>
				<CardTitle>
					{loading && 'Please wait...'}
					{!loading && !success && 'Login Failed'}
				</CardTitle>
				{!loading && !success && (
					<CardDescription>
						Login Failed. Please try again
					</CardDescription>
				)}
			</CardHeader>
			{!loading && !success && (
				<CardFooter>
					<Button>
						<Link href={ROUTE_PATHS.home}>Try Again</Link>
					</Button>
				</CardFooter>
			)}
		</Card>
	);
}

export default ChatLoginContent;
