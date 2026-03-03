import { UserDetailsSetupForm } from '@/features/setup/components';

function UserDetailsSetup() {
	return (
		<div className='p-10'>
			<h2 className='text-3xl mb-20'>Complete User Setup</h2>
			<UserDetailsSetupForm />
		</div>
	);
}

export default UserDetailsSetup;
