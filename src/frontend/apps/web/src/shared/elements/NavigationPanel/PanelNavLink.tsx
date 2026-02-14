import { ReactNode } from 'react';
import { ArrowRight } from 'lucide-react';
import { Url } from 'next/dist/shared/lib/router/router';
import Link from 'next/link';
import { cn } from '@repo/ui/lib/utils';
import { useMenuPanelActions } from '@/shared/hooks';

interface PanelNavLinkProps {
	href: Url;
	children: ReactNode;
	className?: string;
}

const PanelNavLink = ({ href, children, className }: PanelNavLinkProps) => {
	const { closeMenu } = useMenuPanelActions();

	return (
		<Link
			href={href}
			className={cn(
				`px-10 py-5 sm:px-20 sm:py-10 flex-1 w-full border-b
				border-[#ffffff57] font-light flex flex-row justify-between
				items-center relative group/panel-link`,
				className,
			)}
			onClick={() => closeMenu()}
		>
			<span className='z-110 group-hover/panel-link:ps-10 duration-300'>
				{children}{' '}
			</span>
			<span
				className='border border-[#ffffff6f] rounded-full py-3 px-7
					z-110'
			>
				<ArrowRight size={20} />
			</span>
			<span
				className='absolute top-1/2 translate-y-[-50%] inline-block
					w-full left-0 h-0 group-hover/panel-link:h-full bg-[#503c7c]
					duration-300'
			></span>
		</Link>
	);
};

export default PanelNavLink;
