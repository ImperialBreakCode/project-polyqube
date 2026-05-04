'use client';

import { useCallback, useEffect, useMemo, useState } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import SelectProfilePicture from './SelectProfilePicture';
import { AppButton } from '@/shared/elements/AppButton';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import { useCurrentUser, useSetProfilePicture } from '@/shared/api';
import { ErrorAlert } from '@repo/ui/core';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

const SetProfilePicture = () => {
	const router = useRouter();
	const { currentUser, error: currentUserError } = useCurrentUser();
	const { setProfilePicture, loading, error } = useSetProfilePicture();

	const [frontEndError, setFronendError] = useState<string | null>(null);
	const [profilePic, setProfilePic] = useState<File | null | undefined>();

	const profileImageUrl = useMemo(() => {
		if (!profilePic) return null;
		return URL.createObjectURL(profilePic);
	}, [profilePic]);

	const onSaveProfilePic = useCallback(async () => {
		if (profilePic) {
			const { statusCode } = await setProfilePicture(profilePic);

			if (statusCode === STATUS_CODES.noContent) {
				router.push(ROUTE_PATHS.userPanel.homeDashboard);
			}
		}
	}, [setProfilePicture, profilePic, router]);

	useEffect(() => {
		return () => {
			if (profileImageUrl) {
				URL.revokeObjectURL(profileImageUrl);
			}
		};
	}, [profileImageUrl]);

	return (
		<div className='flex flex-col gap-y-10'>
			{currentUserError ? (
				<div>
					<ErrorAlert title='Error' className='w-full'>
						Server error. Please try again
					</ErrorAlert>
				</div>
			) : (
				<>
					<div
						className='flex flex-col items-center gap-y-5 border
							rounded-sm py-10'
					>
						<Avatar className='h-30 w-30 rounded-full'>
							<AvatarImage
								src={profileImageUrl ?? '...'}
								alt={profilePic?.name}
							/>
							<AvatarFallback className='rounded-lg'>
								{currentUser?.userDetails?.firstName[0]}
								{currentUser?.userDetails?.lastName[0]}
							</AvatarFallback>
						</Avatar>
						<div className='text-center'>
							<p className='text-2xl'>
								{currentUser?.userDetails?.firstName}{' '}
								{currentUser?.userDetails?.lastName}
							</p>
							<p className='text-md text-muted-foreground'>
								{
									currentUser?.emails.find((x) => x.isPrimary)
										?.email
								}
							</p>
						</div>
					</div>

					{frontEndError ||
						(error && (
							<div>
								<ErrorAlert title='Error' className='w-full'>
									{(frontEndError ?? error)
										? 'Server error. Please try again'
										: ''}
								</ErrorAlert>
							</div>
						))}

					<SelectProfilePicture
						onError={(message) => setFronendError(message)}
						onSelectedImageChange={(val) => {
							setProfilePic(val);
							setFronendError(null);
						}}
					/>

					<div className='flex gap-x-4'>
						<AppButton
							onClick={() => onSaveProfilePic()}
							disabled={!profilePic || loading}
						>
							{loading ? 'Saving...' : 'Save'}
						</AppButton>
						<AppButton variant={'secondary'} asChild>
							<Link href={ROUTE_PATHS.userPanel.homeDashboard}>
								Skip
							</Link>
						</AppButton>
					</div>
				</>
			)}
		</div>
	);
};

export default SetProfilePicture;
