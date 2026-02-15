import { ReactNode } from 'react';

function AuthLayout({ children }: { children: ReactNode }) {
	return (
		<div className='h-screen p-2 bg-black text-white'>
			<div className='flex h-full space-x-2'>
				<div className='bg-amber-900 flex-1 rounded-md'></div>
				<div className='bg-[#202020] flex-1 rounded-md'>{children}</div>
			</div>
		</div>
	);
}

export default AuthLayout;
