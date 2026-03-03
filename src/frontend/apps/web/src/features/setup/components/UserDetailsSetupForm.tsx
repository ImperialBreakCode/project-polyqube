'use client';

import { useCallback } from 'react';
import z from 'zod';
import { GENDER_LABELS, GenderEnum } from '@/shared/constants/genderEnum';
import { AppForm, DatePickerController, SelectController } from '@repo/ui/core';
import { WebAppTextController } from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';
import { SelectValue } from '@repo/ui/components/Fields/SelectField';

const userDetailsSetupFormSchema = z.object({
	firstName: z.string(),
	lastName: z.string(),
	birthDate: z.date(),
	gender: z.enum(GenderEnum),
});

const UserDetailsSetupForm = () => {
	const genderValues: SelectValue[] = Object.entries(GENDER_LABELS).map(
		([key, val]) => ({
			label: val,
			value: key,
		}),
	);

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
				defaultValues={{
					firstName: '',
					lastName: '',
				}}
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
							name='birthDate'
							placeholder='Select your birthdate'
						/>
						<SelectController
							label='Gender'
							name='gender'
							placeholder='Select your gender'
							values={genderValues}
						/>
					</div>
				</div>
				<AppButton type='submit'>Next</AppButton>
			</AppForm>
		</div>
	);
};

export default UserDetailsSetupForm;
