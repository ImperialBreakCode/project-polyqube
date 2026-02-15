import { ReactNode } from 'react';
import FloatingLines from '@repo/ui/components/FloatingLines';

function AuthLayout({ children }: { children: ReactNode }) {
	return (
		<div className='h-screen p-2 bg-black text-white'>
			<div className='flex h-full space-x-2'>
				<div className='flex-1 rounded-md'>
					<FloatingLines lineCount={5} lineDistance={15} />
				</div>
				<div className='bg-[#202020] flex-1 rounded-md'>{children}</div>
			</div>
		</div>
	);
}

export default AuthLayout;
