import { ReactNode } from 'react';

function InfoPanelsLayout({ children }: { children: ReactNode }) {
	return (
		<div className='dark flex justify-center items-center h-screen'>
			<div className='w-[40%]'>{children}</div>
		</div>
	);
}

export default InfoPanelsLayout;
