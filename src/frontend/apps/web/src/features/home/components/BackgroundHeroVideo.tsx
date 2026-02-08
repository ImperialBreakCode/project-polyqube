const BackgroundHeroVideo = () => {
	return (
		<>
			<video
				autoPlay
				muted
				loop
				className='hidden lg:block absolute top-0 left-0 h-full w-full
					object-cover brightness-85'
			>
				<source src='/landing-page-bg.mp4' type='video/mp4' />
			</video>
			<div
				className='block lg:hidden absolute top-0 left-0 h-full w-full
					bg-[url(/photo-landing-about.jpg)] bg-right'
			></div>
		</>
	);
};

export default BackgroundHeroVideo;
