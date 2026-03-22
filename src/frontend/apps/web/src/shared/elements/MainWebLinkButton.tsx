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
				`group/main-link relative mb-3 w-fit rounded-full border
				border-[#ffffff4e] px-7 py-4 text-xl overflow-hidden
				active:scale-95 transition duration-75`,
				className,
			)}
		>
			{children}
			<span
				className='absolute top-1/2 left-1/2 inline-block h-0 w-0
					group-hover/main-link:w-full group-hover/main-link:h-full
					bg-[#ffffff] bg-blend-exclusion mix-blend-difference
					duration-200 translate-x-[-50%] translate-y-[-50%]
					rounded-full ease-[cubic-bezier(0.1, 0.21, 0.01, 0.86)]'
			></span>
		</Link>
	);
};

export default MainWebLinkButton;
