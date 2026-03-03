'use client';

import { useEffect, useMemo, useState } from 'react';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import SelectProfilePicture from './SelectProfilePicture';
import { AppButton } from '@/shared';

const SetProfilePicture = () => {
	const [profilePic, setProfilePic] = useState<File | null | undefined>();

	const profileImageUrl = useMemo(() => {
		if (!profilePic) return null;
		return URL.createObjectURL(profilePic);
	}, [profilePic]);

	useEffect(() => {
		return () => {
			if (profileImageUrl) {
				URL.revokeObjectURL(profileImageUrl);
			}
		};
	}, [profileImageUrl]);

	return (
		<div className='flex flex-col gap-y-10'>
			<div
				className='flex flex-col items-center gap-y-5 border rounded-sm
					py-10'
			>
				<Avatar className='h-30 w-30 rounded-full'>
					<AvatarImage
						src={profileImageUrl ?? '...'}
						alt={profilePic?.name}
					/>
					<AvatarFallback className='rounded-lg'>CN</AvatarFallback>
				</Avatar>
				<div className='text-center'>
					<p className='text-2xl'>name name</p>
					<p className='text-md text-muted-foreground'>
						email@email.mail
					</p>
				</div>
			</div>

			<SelectProfilePicture
				onSelectedImageChange={(val) => setProfilePic(val)}
			/>

			<div className='flex gap-x-4'>
				<AppButton disabled={!profilePic}>Save</AppButton>
				<AppButton variant={'secondary'}>Skip</AppButton>
			</div>
		</div>
	);
};

export default SetProfilePicture;
