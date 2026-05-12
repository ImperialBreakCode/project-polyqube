'use client';

import { Button } from '@repo/ui/components/ui/Button';
import {
	Dialog,
	DialogContent,
	DialogFooter,
	DialogHeader,
	DialogTitle,
} from '@repo/ui/components/ui/Dialog';
import { Switch } from '@repo/ui/components/ui/Switch';

type ChatSettingsDialogProps = {
	isOpen: boolean;
	aiEnabled: boolean;
	loading: boolean;
	chatId?: string;
	onOpenChange: (open: boolean) => void;
	onAiEnabledChange: (value: boolean) => void;
	onSave: () => Promise<void>;
};

function ChatSettingsDialog({
	isOpen,
	aiEnabled,
	loading,
	chatId,
	onOpenChange,
	onAiEnabledChange,
	onSave,
}: ChatSettingsDialogProps) {
	return (
		<Dialog open={isOpen} onOpenChange={onOpenChange}>
			<DialogContent showCloseButton>
				<DialogHeader>
					<DialogTitle>Chat settings</DialogTitle>
				</DialogHeader>
				<div className='py-2'>
					<label htmlFor='aiEnabled' className='flex items-center justify-between gap-3'>
						<span>AI enabled</span>
						<Switch
							id='aiEnabled'
							checked={aiEnabled}
							onCheckedChange={onAiEnabledChange}
							disabled={loading}
						/>
					</label>
				</div>
				<DialogFooter>
					<Button
						variant='outline'
						onClick={() => onOpenChange(false)}
						disabled={loading}
					>
						Cancel
					</Button>
					<Button onClick={onSave} disabled={loading || !chatId}>
						Save
					</Button>
				</DialogFooter>
			</DialogContent>
		</Dialog>
	);
}

export default ChatSettingsDialog;
