import { BsThreeDots } from 'react-icons/bs';
import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Button } from '@repo/ui/components/ui/Button';
import { Input } from '@repo/ui/components/ui/Input';
import { ScrollArea } from '@repo/ui/components/ui/ScrollArea';
import { SendHorizontal, Sparkles } from 'lucide-react';

function ChatPage() {
	return (
		<div className='h-screen flex flex-col'>
			<div className='flex px-2 py-4 bg-[#28232d]'>
				<div className='flex items-center gap-x-2'>
					<Avatar className='h-8 w-8 rounded-full'>
						<AvatarImage src={'...'} alt={''} />
						<AvatarFallback
							className='rounded-full uppercase bg-transparent'
						>
							TC
						</AvatarFallback>
					</Avatar>{' '}
					<p>Thomas Collin</p>
				</div>

				<Button
					className='rounded-full ms-auto hover:bg-[#84848445]'
					variant={'ghost'}
				>
					<BsThreeDots />
				</Button>
			</div>

			<ScrollArea>
				<div className='flex flex-col justify-end gap-y-2 min-h-screen'>
					<div>
						<div className='border max-w-[20%] rounded-md p-4 mx-4'>
							<p>message</p>
						</div>
					</div>

					<div>
						<div
							className='bg-[#3b3b3b] max-w-[20%] rounded-md p-4
								mx-4 ms-auto'
						>
							<p>message</p>
						</div>
					</div>
				</div>
			</ScrollArea>

			<div className='flex mt-auto pt-4 pb-10 px-2'>
				<Button
					variant={'outline'}
					className='rounded-full border-[#686868]'
				>
					<Sparkles />
				</Button>
				<Input className='rounded-full border-[#686868]' />
				<Button className='rounded-full'>
					<SendHorizontal />
				</Button>
			</div>
		</div>
	);
}

export default ChatPage;
