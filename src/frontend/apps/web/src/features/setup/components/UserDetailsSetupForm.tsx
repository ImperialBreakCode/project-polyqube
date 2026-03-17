'use client';

import { useCallback, useContext } from 'react';
import { useRouter } from 'next/navigation';
import z from 'zod';
import { toDateOnlyString } from '@repo/utils/utilFuncs/dateUtils';
import { AppForm, ErrorAlert, SelectFieldValue } from '@repo/ui/core';
import { GENDER_LABELS, GenderEnum } from '@/shared/constants/genderEnum';
import { AppButton } from '@/shared/elements/AppButton';
import {
	WebAppTextController,
	WebSelectController,
} from '@/shared/elements/FieldControllers';
import WebDateController from '@/shared/elements/FieldControllers/WebDateController';
import { SessionContext } from '@/shared/contexts';
import { ROUTE_PATHS, STATUS_CODES } from '@/shared/constants';
import { useCreateUserDetails } from '../api';

const userDetailsSetupFormSchema = z.object({
	firstName: z.string(),
	lastName: z.string(),
	birthdate: z.date(),
	gender: z.enum(GenderEnum),
});

const UserDetailsSetupForm = () => {
	const router = useRouter();
	const { updateSession } = useContext(SessionContext);
	const { createUserDetails, errorMessage, formErrors, loading } =
		useCreateUserDetails();

	const genderValues: SelectFieldValue[] = Object.entries(GENDER_LABELS).map(
		([key, val]) => ({
			label: val,
			value: key,
		}),
	);

	const onSubmit = useCallback(
		async ({
			birthdate,
			firstName,
			gender,
			lastName,
		}: z.infer<typeof userDetailsSetupFormSchema>) => {
			const { statusCode } = await createUserDetails({
				firstName,
				lastName,
				gender,
				birthdate: toDateOnlyString(birthdate),
			});

			if (statusCode === STATUS_CODES.created) {
				router.push(ROUTE_PATHS.setup.profilePicture);
				await updateSession();
			}
		},
		[createUserDetails, updateSession, router],
	);

	return (
		<div>
			<AppForm
				onSubmit={onSubmit}
				name='user-details-setup'
				schema={userDetailsSetupFormSchema}
				defaultValues={{
					firstName: '',
					lastName: '',
				}}
				errors={formErrors}
			>
				{errorMessage && (
					<ErrorAlert title='Login error' className='mb-10 w-full'>
						{errorMessage}
					</ErrorAlert>
				)}

				<div className='space-y-10 mb-7'>
					<WebAppTextController
						label='First Name'
						name='firstName'
						placeholder='Enter your first name...'
					/>
					<WebAppTextController
						label='Last Name'
						name='lastName'
						placeholder='Enter your last name...'
					/>
					<div
						className='flex flex-col sm:flex-row space-y-10
							space-x-0 sm:space-x-3'
					>
						<WebDateController
							label='Birthdate'
							name='birthdate'
							placeholder='Select your birthdate'
						/>
						<WebSelectController
							label='Gender'
							name='gender'
							placeholder='Select your gender'
							values={genderValues}
						/>
					</div>
				</div>
				<AppButton disabled={loading} type='submit'>
					{loading ? 'Please wait...' : 'Next'}
				</AppButton>
			</AppForm>
		</div>
	);
};

export default UserDetailsSetupForm;
