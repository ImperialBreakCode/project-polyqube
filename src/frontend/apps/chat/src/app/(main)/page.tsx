import { ProfileResultButton } from '@/features/findChat';
import { Input } from '@repo/ui/components/ui/Input';

function MainPage() {
	return (
		<div className='flex flex-col items-center'>
			<div className='flex flex-col items-center p-4 w-2/3 mt-[5%]'>
				<h3 className='text-3xl my-10 text-muted-foreground'>
					Search or Add Chat
				</h3>
				<Input placeholder='Search or Add Chat' />

				<div className='mt-2 w-full'>
					<ProfileResultButton
						avatarFallback='TC'
						name='Thomas Collin'
						avatarSrc='...'
					/>
				</div>
			</div>
		</div>
	);
}

export default MainPage;
