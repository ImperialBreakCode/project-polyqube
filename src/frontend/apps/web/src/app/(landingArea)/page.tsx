import {
	BackgroundHeroVideo,
	GradientLayer,
	HomeTitle,
	Tagline,
} from '@/features/home';
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
			<section className='flex px-20 py-40'>
				<div className='flex flex-1 flex-col justify-between'>
					<p>about</p>
					<Link
						href={'#'}
						className='mb-3 w-fit rounded-full border px-7 py-4 text-xl'
					>
						Go to About →
					</Link>
				</div>
				<div className='flex-1 text-4xl font-light'>
					<p className='leading-15 text-[#ffffffa1]'>
						<span className='font-medium text-white'>PolyQube</span>{' '}
						provides a{' '}
						<span className='font-medium text-white'>
							single login
						</span>{' '}
						for all your digital tools, bringing chat, social, and
						other services together in one convenient{' '}
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
			</section>
		</div>
	);
}
