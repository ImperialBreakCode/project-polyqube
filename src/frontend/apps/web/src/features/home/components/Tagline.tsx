const AccentedWord = ({ children }: { children: React.ReactNode }) => {
	return (
		<span className='font-merriweather-italic font-normal'>{children}</span>
	);
};

const Tagline = () => {
	return (
		<p className='relative z-10 mb-[23vh] text-4xl leading-15 font-light text-[#ececec]'>
			→ One <AccentedWord>login</AccentedWord>. Unlimited services. <br />{' '}
			A <AccentedWord>unified</AccentedWord> account for all your
			connected <AccentedWord>platforms</AccentedWord>.
		</p>
	);
};

export default Tagline;
