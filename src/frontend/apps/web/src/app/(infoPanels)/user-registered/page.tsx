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

function UserRegistered() {
	return (
		<Card className='dark:bg-[#171717] rounded-xl'>
			<CardHeader>
				<CardTitle>User Registred</CardTitle>
				<CardDescription>
					Registration successful! Please verify your email using the
					link we sent before logging in.
				</CardDescription>
			</CardHeader>
			<CardFooter className='flex-col items-stretch'>
				<AppButton asChild>
					<Link href={ROUTE_PATHS.home}>Go to Home Page</Link>
				</AppButton>
			</CardFooter>
		</Card>
	);
}

export default UserRegistered;
