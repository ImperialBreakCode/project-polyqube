import { LoginForm } from '@/features/auth/components';

function Login() {
	return (
		<div className='p-10'>
			<h2 className='text-3xl mb-20'>Login to your account</h2>
			<LoginForm />
		</div>
	);
}

export default Login;
