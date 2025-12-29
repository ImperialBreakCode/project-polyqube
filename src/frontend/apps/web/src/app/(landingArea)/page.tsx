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
				<div
					className='flex flex-1 flex-col items-end justify-between
						border-r border-r-[#ffffff3a] pe-10'
				>
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
			<section className='pb-10'>
				<div
					className='bg-[#3d324f] mx-5 rounded-xl p-10 flex
						space-x-20'
				>
					<div
						className='flex flex-1 flex-col items-end space-y-50
							border-r border-r-[#ffffff3a] pe-10'
					>
						<p className='text-[#dbc7ffdb]'>2 - services</p>

						<MainWebLinkButton
							href={'#'}
							className='border-[#dbc7ff6d]'
						>
							Explore Services →
						</MainWebLinkButton>
					</div>
					<div className='flex flex-2 flex-col font-light'>
						<p className='text-2xl text-[#ffffffda]'>
							PolyQube services are being introduced gradually. At
							the moment, we offer a single service: a real-time
							chat application for private and group messaging.
						</p>

						<p className='text-xl text-[#dbc7ffdb] mt-15'>
							→ <span className='text-white italic'>QLink</span>{' '}
							is the first and only service at the moment. It is
							encrypted and secure, chat app, providing a safe and
							private communication experience.
						</p>
					</div>
				</div>
			</section>
		</div>
	);
}
