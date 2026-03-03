'use client';

import { useCallback } from 'react';
import z from 'zod';
import { GenderEnum } from '@/shared/constants/genderEnum';
import { AppForm, DatePickerController } from '@repo/ui/core';
import { WebAppTextController } from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';

const userDetailsSetupFormSchema = z.object({
	firstName: z.string(),
	lastName: z.email(),
	birthDate: z.iso.date(),
	gender: z.enum(GenderEnum),
});

const UserDetailsSetupForm = () => {
	const onSubmit = useCallback(
		(data: z.infer<typeof userDetailsSetupFormSchema>) => {
			console.log(data);
		},
		[],
	);

	return (
		<div>
			<AppForm
				onSubmit={onSubmit}
				name='user-details-setup'
				schema={userDetailsSetupFormSchema}
			>
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
						<DatePickerController
							label='Birthdate'
							name='birthdate'
							placeholder='Select your birthdate'
						/>
						{/* <WebAppPasswordController
							label='Confirm password'
							name='confirmPassword'
							placeholder='Confirm your password...'
						/> */}
					</div>
				</div>
				<AppButton type='submit'>Next</AppButton>
			</AppForm>
		</div>
	);
};

export default UserDetailsSetupForm;
