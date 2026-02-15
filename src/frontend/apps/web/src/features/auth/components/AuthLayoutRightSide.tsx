import FloatingLines from '@repo/ui/components/FloatingLines';

const AuthLayoutRightSide = () => {
	return (
		<>
			<h1 className='text-7xl absolute bottom-7 left-7'>Auth Title</h1>
			<FloatingLines lineCount={5} lineDistance={15} />
		</>
	);
};

export default AuthLayoutRightSide;
