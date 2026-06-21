'use client';

import { Button } from '@repo/ui/components/ui/Button';
import { Input } from '@repo/ui/components/ui/Input';
import { SendHorizontal, Sparkles } from 'lucide-react';
import {
	startTransition,
	useEffect,
	useState,
	type SubmitEventHandler,
} from 'react';

import type { ChatSendOptions } from '../hooks';

type ChatComposerProps = {
	aiEnabled: boolean;
	sendDisabled?: boolean;
	onSend: (
		text: string,
		options?: ChatSendOptions,
	) => void | Promise<void>;
	onTyping?: () => void;
};

function ChatComposer({
	aiEnabled,
	sendDisabled,
	onSend,
	onTyping,
}: ChatComposerProps) {
	const [draft, setDraft] = useState('');
	const [agentAssistOn, setAgentAssistOn] = useState(false);

	useEffect(() => {
		if (!aiEnabled) {
			startTransition(() => {
				setAgentAssistOn(false);
			});
		}
	}, [aiEnabled]);

	const handleSubmit: SubmitEventHandler<HTMLFormElement> = async (event) => {
		event.preventDefault();
		const text = draft.trim();
		if (!text || sendDisabled) {
			return;
		}
		setDraft('');
		await onSend(text, {
			requestAgentReply: aiEnabled && agentAssistOn,
		});
	};

	return (
		<form
			className='flex mt-auto pt-4 pb-10 px-2 gap-2 items-center'
			onSubmit={handleSubmit}
		>
			{aiEnabled && (
				<Button
					type='button'
					variant={agentAssistOn ? 'default' : 'outline'}
					className='rounded-full border-[#686868]'
					aria-pressed={agentAssistOn}
					title={
						agentAssistOn
							? 'Agent reply on: your next message will also go to the AI'
							: 'Turn on to get an AI reply after your message'
					}
					onClick={() => setAgentAssistOn((previous) => !previous)}
				>
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
