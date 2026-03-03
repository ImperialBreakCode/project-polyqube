import SetProfilePicture from '@/features/setup/components/SetProfilePicture';

function SetupProfileImage() {
	return (
		<div className='p-10'>
			<h2 className='text-3xl mb-20'>Add Profile Picture</h2>
			<div>
				<SetProfilePicture />
			</div>
		</div>
	);
}

export default SetupProfileImage;
