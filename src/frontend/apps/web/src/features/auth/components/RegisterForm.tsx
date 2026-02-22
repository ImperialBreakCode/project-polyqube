'use client';

import { useCallback } from 'react';
import z from 'zod';
import { AppForm } from '@repo/ui/core';
import {
	WebAppEmailController,
	WebAppPasswordController,
	WebAppTextController,
} from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';

const registerFormSchema = z.object({
	username: z.string(),
	email: z.email(),
	password: z.string(),
	confirmPassword: z.string(),
});

const RegisterForm = () => {
	const onSubmit = useCallback((data: z.infer<typeof registerFormSchema>) => {
		console.log(data);
	}, []);

	return (
		<div>
			<AppForm
				onSubmit={onSubmit}
				name='register'
				schema={registerFormSchema}
				defaultValues={{
					confirmPassword: '',
					password: '',
					email: '',
					username: '',
				}}
			>
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
				<AppButton type='submit'>Register</AppButton>
			</AppForm>
		</div>
	);
};

export default RegisterForm;
