'use client';

import { useCallback, useEffect, useState } from 'react';
import Link from 'next/link';
import {
	Card,
	CardContent,
	CardFooter,
	CardHeader,
	CardTitle,
} from '@repo/ui/core';
import { AppButton } from '@/shared';
import { useCreateChatProfile, useGetCurrentChatProfile } from '../api';
import { getChatAppHost } from '@/server';

const ServicesList = () => {
	const { loading, success, refetchProfile, chatProfile } =
		useGetCurrentChatProfile();

	const {
		loading: createLoading,
		success: createSuccess,
		createProfile,
	} = useCreateChatProfile();

	const [chatHost, setChatHost] = useState<string | null>();

	useEffect(() => {
		const loadChatHost = async () => {
			const chatHost = await getChatAppHost();
			setChatHost(chatHost);
		};

		loadChatHost();
	}, []);

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

					{success && (
						<AppButton asChild>
							<Link href={chatHost ?? '#'}>Go to Chat</Link>
						</AppButton>
					)}
				</CardFooter>
			</Card>
		</div>
	);
};

export default ServicesList;
