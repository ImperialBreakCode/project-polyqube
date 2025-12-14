import { HomeTitle } from '@/features/home';

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

			<div className='absolute top-0 left-0 h-full w-full bg-linear-to-r from-[#000000b7] to-transparent'></div>

			<div className='flex h-screen flex-col justify-end'>
				<HomeTitle />
			</div>
		</section>
	);
}
