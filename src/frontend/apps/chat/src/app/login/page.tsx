'use client';

import { ChatLoginContent } from '@/features/auth';
import { Suspense } from 'react';

function ChatLoginPage() {
	return (
		<div className='flex items-center justify-center h-screen'>
			<Suspense>
				<ChatLoginContent />
			</Suspense>
		</div>
	);
}

export default ChatLoginPage;
