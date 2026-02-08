import { ReactNode } from 'react';
import { Url } from 'next/dist/shared/lib/router/router';
import Link from 'next/link';
import { ArrowRight } from 'lucide-react';

interface PanelNavLinkSmallProps {
	href: Url;
	children: ReactNode;
}

const PanelNavLinkSmall = ({ href, children }: PanelNavLinkSmallProps) => {
	return (
		<Link
			className='text-sm rounded-full border border-[#ffffff4f] pl-4 pr-2
				py-2 md:pl-7 md:pr-3 md:py-3 cursor-pointer hover:bg-[#d8d8d8]
				hover:text-black uppercase duration-100 flex flex-row
				items-center'
			href={href}
		>
			<span>{children} </span>
			<span className='rounded-full bg-[#d8d8d8] inline-block ml-10'>
				<ArrowRight size={30} className='text-black p-2' />
			</span>
		</Link>
	);
};

export default PanelNavLinkSmall;
