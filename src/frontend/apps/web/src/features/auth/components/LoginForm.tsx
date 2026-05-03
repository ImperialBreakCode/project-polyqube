'use client';

import { useCallback, useContext } from 'react';
import { useRouter, useSearchParams } from 'next/navigation';
import z from 'zod';
import { AppForm, ErrorAlert } from '@repo/ui/core';
import {
	WebAppPasswordController,
	WebAppTextController,
} from '@/shared/elements/FieldControllers';
import { AppButton } from '@/shared/elements/AppButton';
import { ROUTE_PATHS } from '@/shared/constants/routes';
import { STATUS_CODES } from '@/shared/constants/statusCodes';
import { SessionContext } from '@/shared/contexts';
import { useUserLogin } from '../api';
import { URL_QUERY_KEYS } from '@/shared';

const loginFormSchema = z.object({
	username: z.string(),
	password: z.string(),
});

const LoginForm = () => {
	const router = useRouter();

	const searchParams = useSearchParams();
	const callbackUrl = searchParams.get(URL_QUERY_KEYS.callbackUrl);

	const { loginFormErrors, login, loading, errorMessage } = useUserLogin();
	const { updateSession } = useContext(SessionContext);

	const onSubmit = useCallback(
		async (data: z.infer<typeof loginFormSchema>) => {
			const { statusCode } = await login(data);

			if (statusCode === STATUS_CODES.ok) {
				router.push(callbackUrl ?? ROUTE_PATHS.userPanel.homeDashboard);
				await updateSession();
			}
		},
		[login, router, updateSession, callbackUrl],
	);

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
				errors={loginFormErrors}
				resetAfterSubmit
			>
				{errorMessage && (
					<ErrorAlert title='Login error' className='mb-10 w-full'>
						{errorMessage}
					</ErrorAlert>
				)}

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
				<AppButton disabled={loading} type='submit'>
					{loading ? 'Please wait...' : 'Login'}
				</AppButton>
			</AppForm>
		</div>
	);
};

export default LoginForm;
