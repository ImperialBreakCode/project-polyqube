'use client';

import { useCallback } from 'react';
import z from 'zod';
import {
	AppForm,
	EmailFieldController,
	PasswordFieldController,
	TextFieldController,
} from '@repo/ui/core';

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
				<TextFieldController
					label='Username'
					name='username'
					placeholder='Enter your username...'
				/>
				<EmailFieldController
					label='Email'
					name='email'
					placeholder='Enter your email...'
				/>
				<PasswordFieldController
					label='Password'
					name='password'
					placeholder='Enter your password...'
				/>
				<PasswordFieldController
					label='Confirm password'
					name='confirmPassword'
					placeholder='Confirm your password...'
				/>
			</AppForm>
		</div>
	);
}

export default Register;
