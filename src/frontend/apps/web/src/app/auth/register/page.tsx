'use client';

import { useCallback } from 'react';
import z from 'zod';
import { AppForm } from '@repo/ui/core';
import {
	WebAppEmailController,
	WebAppPasswordController,
	WebAppTextController,
} from '@/shared/elements/FieldControllers';

const registerFormSchema = z.object({
	username: z.string(),
	email: z.email(),
	password: z.string(),
	confirmPassword: z.string(),
});

function Register() {
	const onSubmit = useCallback((data: z.infer<typeof registerFormSchema>) => {
		console.log(data);
	}, []);

	return (
		<div className='p-10'>
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
				<div className='space-y-10'>
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
			</AppForm>
		</div>
	);
}

export default Register;
