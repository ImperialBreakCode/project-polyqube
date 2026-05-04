'use client';

import { LoginForm } from '@/features/auth/components';
import { Suspense } from 'react';

function Login() {
	return (
		<div className='p-10'>
			<h2 className='text-3xl mb-20'>Login to your account</h2>
			<Suspense fallback={<div></div>}>
				<LoginForm />
			</Suspense>
		</div>
	);
}

export default Login;
