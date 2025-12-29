import Image from 'next/image';
import {
	AboutText,
	BackgroundHeroVideo,
	GradientLayer,
	HomeTitle,
	Tagline,
} from '@/features/home';
import { MainWebLinkButton } from '@/shared';

export default function Home() {
	return (
		<div className='bg-zinc-900 text-white'>
			<section className='relative h-screen'>
				<BackgroundHeroVideo />

				<GradientLayer />

				<div className='flex h-screen flex-col justify-end ps-5'>
					<Tagline />
					<HomeTitle />
				</div>
			</section>
			<section className='flex space-x-20 px-20 py-40'>
				<div className='flex flex-1 flex-col items-end justify-between border-r border-r-[#ffffff3a] pe-10'>
					<p className='mb-10'>1 - about</p>
					<Image
						src={'/photo-landing-about.jpg'}
						alt='Cube with name on it - polyqube'
						width={500}
						height={500}
						className='rounded-lg'
					/>
				</div>
				<div className='flex flex-2 flex-col justify-between font-light'>
					<AboutText />

					<MainWebLinkButton href={'#'}>
						Go to About →
					</MainWebLinkButton>
				</div>
			</section>
		</div>
	);
}
