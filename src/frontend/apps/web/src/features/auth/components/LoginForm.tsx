'use client';

import { useCallback } from 'react';
import z from 'zod';
import { AppForm } from '@repo/ui/core';
import {
	WebAppPasswordController,
	WebAppTextController,
} from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';

const loginFormSchema = z.object({
	username: z.string(),
	password: z.string(),
});

const LoginForm = () => {
	const onSubmit = useCallback((data: z.infer<typeof loginFormSchema>) => {
		console.log(data);
	}, []);

	return (
		<div>
			<AppForm
				onSubmit={onSubmit}
				name='login'
				schema={loginFormSchema}
				defaultValues={{
					password: '',
					username: '',
				}}
			>
				<div className='space-y-10 mb-7'>
					<WebAppTextController
						label='Username'
						name='username'
						placeholder='Enter your username...'
					/>
					<WebAppPasswordController
						label='Password'
						name='password'
						placeholder='Enter your password...'
					/>
				</div>
				<AppButton type='submit'>Login</AppButton>
			</AppForm>
		</div>
	);
};

export default LoginForm;
