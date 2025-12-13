export default function Home() {
	return (
		<section className='relative h-screen'>
			<video
				autoPlay
				muted
				loop
				className='absolute top-0 left-0 h-full w-full object-cover brightness-85'
			>
				<source src='/landing-page-bg.mp4' type='video/mp4' />
			</video>

			<div className='flex h-screen flex-col justify-end'>
				<h1 className='font-merriweather relative z-10 ms-5 mb-[25vh] text-[9rem] text-white uppercase'>
					PolyQube
				</h1>
			</div>
		</section>
	);
}
