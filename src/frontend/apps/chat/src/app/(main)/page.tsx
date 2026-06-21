'use client';

import { ProfileResultButton, useProfileSearch } from '@/features/findChat';
import { UserProfileResponseDTO } from '@/server';
import { CHAT_EVENTS } from '@/shared/constants';
import { Button } from '@repo/ui/components/ui/Button';
import {
	Dialog,
	DialogContent,
	DialogDescription,
	DialogFooter,
	DialogHeader,
	DialogTitle,
} from '@repo/ui/components/ui/Dialog';
import { Input } from '@repo/ui/components/ui/Input';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { usePeerChat } from '@/features/findChat';

function MainPage() {
	const { profiles, searchProfiles } = useProfileSearch();
	const { getPeerChat, createPeerChat, loading, createdPeerChat, peerChat } =
		usePeerChat();
	const router = useRouter();
	const [searchValue, setSearchValue] = useState('');
	const [selectedProfileId, setSelectedProfileId] = useState<string | null>(
		null,
	);
	const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);

	useEffect(() => {
		if (searchValue.trim().length < 2) {
			return;
		}

		const timeout = setTimeout(async () => {
			await searchProfiles(searchValue.trim());
		}, 300);

		return () => {
			clearTimeout(timeout);
		};
	}, [searchProfiles, searchValue]);

	useEffect(() => {
		if (peerChat?.id) {
			router.push(`/${peerChat.id}`);
		}

		if (createdPeerChat?.id) {
			window.dispatchEvent(new Event(CHAT_EVENTS.chatCreated));
			router.push(`/${createdPeerChat.id}`);
		}
	}, [peerChat, createdPeerChat, router]);

	const canShowResults = searchValue.trim().length >= 2;
	const visibleProfiles = useMemo(() => {
		if (!canShowResults) {
			return [];
		}

		return profiles;
	}, [canShowResults, profiles]);

	const buildFallback = (profile: UserProfileResponseDTO) => {
		const first = profile.firstName?.[0] ?? '';
		const last = profile.lastName?.[0] ?? '';
		return `${first}${last}`;
	};

	const handleProfileClick = async (profileId: string) => {
		const { statusCode } = await getPeerChat(profileId);

		if (statusCode === 404) {
			setSelectedProfileId(profileId);
			setIsCreateDialogOpen(true);
		}
	};

	const handleCreateChatConfirm = async () => {
		if (!selectedProfileId) {
			return;
		}

		await createPeerChat(selectedProfileId);
	};

	return (
		<div className='flex flex-col items-center'>
			<div className='flex flex-col items-center p-4 w-2/3 mt-[5%]'>
				<h3 className='text-3xl my-10 text-muted-foreground'>
					Search or Add Chat
				</h3>
				<Input
					placeholder='Search or Add Chat'
					value={searchValue}
					onChange={(e) => setSearchValue(e.target.value)}
				/>

				<div className='mt-2 w-full'>
					{visibleProfiles.map((profile) => (
						<ProfileResultButton
							key={profile.id}
							avatarFallback={buildFallback(profile)}
							name={`${profile.firstName} ${profile.lastName}`}
							avatarSrc={profile.profilePicture}
							onClick={() => handleProfileClick(profile.id)}
							disabled={loading}
						/>
					))}
				</div>
			</div>

			<Dialog
				open={isCreateDialogOpen}
				onOpenChange={setIsCreateDialogOpen}
			>
				<DialogContent showCloseButton>
					<DialogHeader>
						<DialogTitle>Create a new chat?</DialogTitle>
						<DialogDescription>
							No existing peer chat was found with this user. Do
							you want to create one now?
						</DialogDescription>
					</DialogHeader>
					<DialogFooter>
						<Button
							variant='outline'
							onClick={() => setIsCreateDialogOpen(false)}
							disabled={loading}
						>
							Cancel
						</Button>
						<Button
							onClick={handleCreateChatConfirm}
							disabled={loading}
						>
							Create chat
						</Button>
					</DialogFooter>
				</DialogContent>
			</Dialog>
		</div>
	);
}

export default MainPage;
