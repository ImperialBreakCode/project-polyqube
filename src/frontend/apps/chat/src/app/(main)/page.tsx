import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Button } from '@repo/ui/components/ui/Button';
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
					<Button
						variant={'outline'}
						className='w-full justify-start py-[30px!important]
							cursor-pointer'
					>
						<Avatar className='h-8 w-8 rounded-full'>
							<AvatarImage src={'...'} alt={'...'} />
							<AvatarFallback className='rounded-full uppercase'>
								TC
							</AvatarFallback>
						</Avatar>{' '}
						Thomas Collin
					</Button>
				</div>
			</div>
		</div>
	);
}

export default MainPage;
