'use client';

import { Button } from '@repo/ui/components/ui/Button';
import { Input } from '@repo/ui/components/ui/Input';
import { SendHorizontal, Sparkles } from 'lucide-react';

type ChatComposerProps = {
	aiEnabled: boolean;
};

function ChatComposer({ aiEnabled }: ChatComposerProps) {
	return (
		<div className='flex mt-auto pt-4 pb-10 px-2'>
			{aiEnabled && (
				<Button variant='outline' className='rounded-full border-[#686868]'>
					<Sparkles />
				</Button>
			)}
			<Input className='rounded-full border-[#686868]' />
			<Button className='rounded-full'>
				<SendHorizontal />
			</Button>
		</div>
	);
}

export default ChatComposer;
