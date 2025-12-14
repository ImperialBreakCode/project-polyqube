import { BackgroundHeroVideo, GradientLayer, HomeTitle } from '@/features/home';

export default function Home() {
	return (
		<section className='relative h-screen'>
			<BackgroundHeroVideo />

			<GradientLayer />

			<div className='flex h-screen flex-col justify-end'>
				<HomeTitle />
			</div>
		</section>
	);
}
