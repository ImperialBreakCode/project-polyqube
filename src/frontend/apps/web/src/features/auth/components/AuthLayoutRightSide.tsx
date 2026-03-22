'use client';

import { usePathname } from 'next/navigation';
import LiquidEther from '@repo/ui/components/LiquidEther';

const AuthLayoutRightSide = () => {
	const pathname = usePathname();

	return (
		<>
			<h1
				className='text-7xl absolute bottom-15 left-8 capitalize
					font-light z-100'
			>
				{pathname.split('/').splice(-1)[0]!.replace(/-/g, ' ')}
			</h1>
			<LiquidEther
				mouseForce={30}
				resolution={0.5}
				colors={['#8537fb', '#b28af0', '#d0afde']}
			/>
		</>
	);
};

export default AuthLayoutRightSide;
