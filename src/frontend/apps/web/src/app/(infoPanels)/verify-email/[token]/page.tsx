'use client';

import Link from 'next/link';
import {
	Card,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/components/ui/Card';
import { Spinner } from '@repo/ui/components/ui/Spinner';
import { AppButton } from '@/shared/elements/AppButton';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import { useVerifyEmail } from '@/features/email/api';
import { useParams } from 'next/navigation';

function VerifyEmail() {
	const { token } = useParams<{ token: string }>();

	const { loading, success } = useVerifyEmail({
		emailVerificationToken: token,
	});

	return (
		<Card className='dark:bg-[#171717] rounded-xl'>
			<CardHeader>
				{success && (
					<>
						<CardTitle>Email Verified</CardTitle>
						<CardDescription>
							Your email has been verified! Log in to finish
							setting up your account.
						</CardDescription>
					</>
				)}

				{loading ? (
					<CardTitle className='flex flex-row space-x-5 items-center'>
						<Spinner /> <span>Verifying email...</span>
					</CardTitle>
				) : (
					!success && <CardTitle>Could Not Verify Email</CardTitle>
				)}
			</CardHeader>
			<CardFooter className='flex-col space-y-5 items-stretch mt-5'>
				{success && (
					<AppButton asChild>
						<Link href={ROUTE_PATHS.auth.login}>
							Login to Your Account
						</Link>
					</AppButton>
				)}

				<AppButton variant={'secondary'} asChild>
					<Link href={ROUTE_PATHS.home}>Go to Home Page</Link>
				</AppButton>
			</CardFooter>
		</Card>
	);
}

export default VerifyEmail;
