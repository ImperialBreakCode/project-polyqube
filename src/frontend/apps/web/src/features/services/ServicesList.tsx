import { AppButton } from '@/shared';
import {
	Card,
	CardContent,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';

const ServicesList = () => {
	return (
		<div>
			<Card>
				<CardHeader>
					<CardTitle>PolyQube Chat</CardTitle>
				</CardHeader>
				<CardContent>
					<p>Enable and create an account.</p>
				</CardContent>
				<CardFooter>
					<AppButton>Enable</AppButton>
				</CardFooter>
			</Card>
		</div>
	);
};

export default ServicesList;
