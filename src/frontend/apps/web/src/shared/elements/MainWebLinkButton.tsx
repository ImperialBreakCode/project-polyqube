import { ReactNode } from 'react';
import { Url } from 'next/dist/shared/lib/router/router';
import Link from 'next/link';
import { cn } from '@repo/ui/lib/utils';

interface MainWebLinkButtonProps {
	href: Url;
	children?: ReactNode;
	className?: string;
}

const MainWebLinkButton = ({
	href,
	children,
	className,
}: MainWebLinkButtonProps) => {
	return (
		<Link
			href={href}
			className={cn(
				`group/main-link relative mb-3 w-fit rounded-full border border-[#ffffff4e] px-7 py-4 text-xl`,
				className,
			)}
		>
			{children}
			<span className='group-hovers/main-link:h-full absolute top-0 left-0 inline-block h-0 w-0 opacity-0 group-hover/main-link:w-full group-hover/main-link:opacity-100'></span>
		</Link>
	);
};

export default MainWebLinkButton;
