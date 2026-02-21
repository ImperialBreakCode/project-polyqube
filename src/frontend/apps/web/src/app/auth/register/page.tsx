import { RegisterForm } from '@/features/auth';

function Register() {
	return (
		<div className='p-10'>
			<h2 className='text-3xl mb-20'>Create an account</h2>
			<RegisterForm />
		</div>
	);
}

export default Register;
