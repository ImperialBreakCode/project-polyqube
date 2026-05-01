'use client';

import {
	Card,
	CardContent,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';
import { AppButton } from '@/shared';
import { useCreateChatProfile, useGetCurrentChatProfile } from '../api';
import { useCallback } from 'react';

const ServicesList = () => {
	const { loading, success, refetchProfile, chatProfile } =
		useGetCurrentChatProfile();

	const {
		loading: createLoading,
		success: createSuccess,
		createProfile,
	} = useCreateChatProfile();

	const onProfileCreate = useCallback(async () => {
		await createProfile();

		if (createSuccess) {
			await refetchProfile();
		}
	}, [createProfile, createSuccess, refetchProfile]);

	return (
		<div>
			<Card>
				<CardHeader>
					<CardTitle>PolyQube Chat</CardTitle>
				</CardHeader>
				<CardContent>
					{loading && <p>loading...</p>}
					{!loading && !chatProfile && (
						<p>Enable service to create an account.</p>
					)}
					{!loading && chatProfile && (
						<p>
							Hello{' '}
							{chatProfile.firstName + ' ' + chatProfile.lastName}
							. Visit the app to start chatting
						</p>
					)}
				</CardContent>
				<CardFooter>
					{loading && <p>loading...</p>}
					{!loading && !success && (
						<AppButton
							onClick={onProfileCreate}
							disabled={createLoading}
						>
							{createLoading ? 'Please wait...' : 'Enable'}
						</AppButton>
					)}
				</CardFooter>
			</Card>
		</div>
	);
};

export default ServicesList;
