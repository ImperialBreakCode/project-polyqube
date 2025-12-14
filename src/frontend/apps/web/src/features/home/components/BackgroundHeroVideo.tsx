const BackgroundHeroVideo = () => {
	return (
		<video
			autoPlay
			muted
			loop
			className='absolute top-0 left-0 h-full w-full object-cover brightness-85'
		>
			<source src='/landing-page-bg.mp4' type='video/mp4' />
		</video>
	);
};

export default BackgroundHeroVideo;
