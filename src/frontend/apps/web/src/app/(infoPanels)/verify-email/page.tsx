import Link from 'next/link';
import {
	Card,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/components/ui/Card';
import { AppButton } from '@/shared/elements/AppButton';
import { ROUTE_PATHS } from '@/shared/constants/routes';

function VerifyEmail() {
	return (
		<Card className='dark:bg-[#171717] rounded-xl'>
			<CardHeader>
				<CardTitle>Email Verified</CardTitle>
				<CardDescription>
					Your email has been verified! Log in to finish setting up
					your account.
				</CardDescription>
			</CardHeader>
			<CardFooter className='flex-col space-y-5 items-stretch mt-5'>
				<AppButton asChild>
					<Link href={ROUTE_PATHS.auth.login}>
						Login to Your Account
					</Link>
				</AppButton>
				<AppButton variant={'secondary'} asChild>
					<Link href={ROUTE_PATHS.home}>Go to Home Page</Link>
				</AppButton>
			</CardFooter>
		</Card>
	);
}

export default VerifyEmail;
