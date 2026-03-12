'use client';

import { useCallback } from 'react';
import z from 'zod';
import { AppForm, ErrorAlert } from '@repo/ui/core';
import {
	WebAppEmailController,
	WebAppPasswordController,
	WebAppTextController,
} from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';
import { useUserRegister } from '../api';
import { useRouter } from 'next/navigation';
import { ROUTE_PATHS } from '@/shared/constants/routes';

const registerFormSchema = z
	.object({
		username: z.string(),
		email: z.email(),
		password: z.string(),
		confirmPassword: z.string(),
	})
	.refine((data) => data.password === data.confirmPassword, {
		message: "Passwords don't match",
		path: ['confirmPassword'],
	});

const RegisterForm = () => {
	const router = useRouter();
	const { register, loading, errorMessage, registerFormErrors } =
		useUserRegister();

	const onSubmit = useCallback(
		async ({
			password,
			email,
			username,
		}: z.infer<typeof registerFormSchema>) => {
			await register({
				email,
				password,
				username,
			});

			router.push(ROUTE_PATHS.infoPanels.userRegistered);
		},
		[register, router],
	);

	return (
		<div>
			<AppForm
				resetAfterSubmit={false}
				onSubmit={onSubmit}
				name='register'
				schema={registerFormSchema}
				errors={registerFormErrors}
				defaultValues={{
					confirmPassword: '',
					password: '',
					email: '',
					username: '',
				}}
			>
				{errorMessage && (
					<ErrorAlert
						title='Registration error'
						className='mb-10 w-full'
					>
						{errorMessage}
					</ErrorAlert>
				)}

				<div className='space-y-10 mb-7'>
					<WebAppTextController
						label='Username'
						name='username'
						placeholder='Enter your username...'
					/>
					<WebAppEmailController
						label='Email'
						name='email'
						placeholder='Enter your email...'
					/>
					<div
						className='flex flex-col sm:flex-row space-y-10
							space-x-0 sm:space-x-3'
					>
						<WebAppPasswordController
							label='Password'
							name='password'
							placeholder='Enter your password...'
						/>
						<WebAppPasswordController
							label='Confirm password'
							name='confirmPassword'
							placeholder='Confirm your password...'
						/>
					</div>
				</div>
				<AppButton disabled={loading} type='submit'>
					{loading ? 'Please wait...' : 'Register'}
				</AppButton>
			</AppForm>
		</div>
	);
};

export default RegisterForm;
