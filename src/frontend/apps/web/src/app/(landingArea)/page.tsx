import Image from 'next/image';

import { MainWebLinkButton, ROUTE_PATHS } from '@/shared';
import {
	AboutText,
	BackgroundHeroVideo,
	GradientLayer,
	HomeTitle,
	Tagline,
} from '@/features/home';

export default function Home() {
	return (
		<div>
			<section className='relative h-screen'>
				<BackgroundHeroVideo />

				<GradientLayer />

				<div className='flex h-screen flex-col justify-end px-5 sm:ps-5'>
					<Tagline />
					<HomeTitle />
				</div>
			</section>
			<section
				className='flex flex-col lg:flex-row space-x-20 px-10 xl:px-20
					py-40'
			>
				<div
					className='flex flex-1 flex-col lg:items-end justify-between
						lg:border-r border-r-[#ffffff3a] pe-10'
				>
					<p className='mb-10'>1 - about</p>
					<Image
						src={'/photo-landing-about.jpg'}
						alt='Cube with name on it - polyqube'
						width={500}
						height={500}
						className='rounded-lg hidden lg:block'
					/>
				</div>
				<div className='flex flex-2 flex-col justify-between font-light'>
					<AboutText />

					<MainWebLinkButton
						className='mt-10'
						href={ROUTE_PATHS.about}
					>
						Go to About →
					</MainWebLinkButton>
				</div>
			</section>
			<section className='pb-10'>
				<div
					className='bg-(--web-accent-color) sm:mx-5 rounded-xl p-10
						flex flex-col lg:flex-row space-x-20'
				>
					<div
						className='flex flex-1 flex-col lg:items-end space-y-10
							lg:space-y-50 lg:border-r lg:border-r-[#ffffff3a]
							pe-10'
					>
						<p className='text-[#dbc7ffdb]'>2 - services</p>

						<MainWebLinkButton
							href={ROUTE_PATHS.services}
							className='border-[#dbc7ff6d] hidden lg:block'
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

						<MainWebLinkButton
							href={ROUTE_PATHS.services}
							className='border-[#dbc7ff6d] block lg:hidden mt-20'
						>
							Explore Services →
						</MainWebLinkButton>
					</div>
				</div>
			</section>
		</div>
	);
}
