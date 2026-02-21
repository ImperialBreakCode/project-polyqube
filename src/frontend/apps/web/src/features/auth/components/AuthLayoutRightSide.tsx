'use client';

import { usePathname } from 'next/navigation';
import FloatingLines from '@repo/ui/components/FloatingLines';

const AuthLayoutRightSide = () => {
	const pathname = usePathname();

	return (
		<>
			<h1
				className='text-7xl absolute bottom-15 left-8 capitalize
					font-light'
			>
				{pathname.split('/').splice(-1)}
			</h1>
			<FloatingLines lineCount={10} lineDistance={300} />
		</>
	);
};

export default AuthLayoutRightSide;
