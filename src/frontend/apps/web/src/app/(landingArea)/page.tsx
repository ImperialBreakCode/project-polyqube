import {
	BackgroundHeroVideo,
	GradientLayer,
	HomeTitle,
	Tagline,
} from '@/features/home';
import Image from 'next/image';
import Link from 'next/link';

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
				<div className='flex flex-1 flex-col items-end justify-between'>
					<Image
						src={'/photo-landing-about.jpg'}
						alt='Cube with name on it - polyqube'
						width={600}
						height={600}
						className='rounded-2xl'
					/>
				</div>
				<div className='flex flex-2 flex-col justify-between font-light'>
					<div>
						<p className='mb-5'>1 - about</p>
						<p className='mb-17 text-3xl text-[#ffffffa1]'>
							<span className='font-medium text-white'>
								PolyQube
							</span>{' '}
							provides a{' '}
							<span className='font-medium text-white'>
								single login
							</span>{' '}
							for all your digital tools, bringing chat, social,
							and other services together in one convenient{' '}
							<span className='font-medium text-white'>
								ecosystem
							</span>
							, so you can stay connected and manage{' '}
							<span className='font-medium text-white'>
								everything
							</span>{' '}
							seamlessly in{' '}
							<span className='font-medium text-white'>
								one place
							</span>
							.
						</p>
					</div>

					<Link
						href={'#'}
						className='mb-3 w-fit rounded-full border px-7 py-4 text-xl'
					>
						Go to About →
					</Link>
				</div>
			</section>
		</div>
	);
}
