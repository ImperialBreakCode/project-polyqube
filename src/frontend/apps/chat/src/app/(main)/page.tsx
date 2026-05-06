'use client';

import { ProfileResultButton, useProfileSearch } from '@/features/findChat';
import { UserProfileResponseDTO } from '@/server';
import { Input } from '@repo/ui/components/ui/Input';
import { useEffect, useMemo, useState } from 'react';

function MainPage() {
	const { profiles, searchProfiles } = useProfileSearch();
	const [searchValue, setSearchValue] = useState('');

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
		console.log(profileId);
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
						/>
					))}
				</div>
			</div>
		</div>
	);
}

export default MainPage;
