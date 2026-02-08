'use client';

import { useIsLargeScreen } from '@/shared';

const BackgroundHeroVideo = () => {
	const isLargeScreen = useIsLargeScreen();

	return (
		<>
			{isLargeScreen ? (
				<video
					autoPlay
					muted
					loop
					className='absolute top-0 left-0 h-full w-full object-cover
						brightness-85'
				>
					<source src='/landing-page-bg.mp4' type='video/mp4' />
				</video>
			) : (
				<div
					className='absolute top-0 left-0 h-full w-full
						bg-[url(/photo-landing-about.jpg)] bg-right'
				></div>
			)}
		</>
	);
};

export default BackgroundHeroVideo;
