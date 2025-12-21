import {
	BackgroundHeroVideo,
	GradientLayer,
	HomeTitle,
	Tagline,
} from '@/features/home';

export default function Home() {
	return (
		<section className='relative h-screen'>
			<BackgroundHeroVideo />

			<GradientLayer />

			<div className='flex h-screen flex-col justify-end ps-5'>
				<Tagline />
				<HomeTitle />
			</div>
		</section>
	);
}
