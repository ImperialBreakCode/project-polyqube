import { BackgroundHeroVideo, GradientLayer, HomeTitle } from '@/features/home';

export default function Home() {
	return (
		<section className='relative h-screen'>
			<BackgroundHeroVideo />

			<GradientLayer />

			<div className='flex h-screen flex-col justify-end ps-5'>
				<p className='relative z-10 mb-20 text-4xl leading-15 font-light text-[#ececec]'>
					→ One{' '}
					<span className='font-merriweather-italic font-normal'>
						login
					</span>
					. Unlimited services. <br /> A{' '}
					<span className='font-merriweather-italic font-normal'>
						unified
					</span>{' '}
					account for all your connected{' '}
					<span className='font-merriweather-italic font-normal'>
						platforms
					</span>
					.
				</p>
				<HomeTitle />
			</div>
		</section>
	);
}
