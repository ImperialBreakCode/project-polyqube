'use client';

import { ReactNode } from 'react';
import { AuthLayoutRightSide } from '@/features/auth';
import { useIsLargeScreen } from '@/shared/hooks/breakpointHooks';

function AuthLayout({ children }: { children: ReactNode }) {
	const isLargeScreen = useIsLargeScreen();

	return (
		<div className='min-h-screen sm:h-screen p-2 bg-black text-white dark'>
			<div className='flex h-full space-x-2'>
				{isLargeScreen && (
					<div className='flex-1 rounded-md relative'>
						<AuthLayoutRightSide />
					</div>
				)}

				<div className='bg-[#151515] flex-1 rounded-md'>{children}</div>
			</div>
		</div>
	);
}

export default AuthLayout;
