'use client';

import {
	Card,
	CardContent,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';
import { AppButton } from '@/shared';
import { useGetCurrentChatProfile } from '../api';

const ServicesList = () => {
	const { loading, success } = useGetCurrentChatProfile();

	return (
		<div>
			<Card>
				<CardHeader>
					<CardTitle>PolyQube Chat</CardTitle>
				</CardHeader>
				<CardContent>
					{loading && <p>loading...</p>}
					{!loading && !success && (
						<p>Enable service to create an account.</p>
					)}
					{!loading && success && <p>Visit the service and chat</p>}
				</CardContent>
				<CardFooter>
					{loading && <p>loading...</p>}
					{!loading && !success && <AppButton>Enable</AppButton>}
				</CardFooter>
			</Card>
		</div>
	);
};

export default ServicesList;
