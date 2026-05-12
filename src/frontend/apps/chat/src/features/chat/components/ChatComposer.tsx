'use client';

import { Button } from '@repo/ui/components/ui/Button';
import { Input } from '@repo/ui/components/ui/Input';
import { SendHorizontal, Sparkles } from 'lucide-react';
import { FormEvent, useState } from 'react';

type ChatComposerProps = {
	aiEnabled: boolean;
	sendDisabled?: boolean;
	onSend: (text: string) => void | Promise<void>;
	onTyping?: () => void;
};

function ChatComposer({
	aiEnabled,
	sendDisabled,
	onSend,
	onTyping,
}: ChatComposerProps) {
	const [draft, setDraft] = useState('');

	const handleSubmit = async (event: FormEvent) => {
		event.preventDefault();
		const text = draft.trim();
		if (!text || sendDisabled) {
			return;
		}
		setDraft('');
		await onSend(text);
	};

	return (
		<form
			className='flex mt-auto pt-4 pb-10 px-2 gap-2 items-center'
			onSubmit={handleSubmit}
		>
			{aiEnabled && (
				<Button type='button' variant='outline' className='rounded-full border-[#686868]'>
					<Sparkles />
				</Button>
			)}
			<Input
				className='rounded-full border-[#686868] flex-1'
				value={draft}
				disabled={sendDisabled}
				onChange={(event) => {
					setDraft(event.target.value);
					if (event.target.value && !sendDisabled) {
						onTyping?.();
					}
				}}
				placeholder='Message'
			/>
			<Button type='submit' className='rounded-full' disabled={sendDisabled || !draft.trim()}>
				<SendHorizontal />
			</Button>
		</form>
	);
}

export default ChatComposer;
