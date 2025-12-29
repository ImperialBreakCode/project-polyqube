import Link from 'next/link';
import { Url } from 'next/dist/shared/lib/router/router';

import { NavigationMenuLink } from '@repo/ui/core';
import { cn } from '@repo/ui/lib/utils';

interface MainNavLinkProps {
	href: Url;
	children: React.ReactNode;
	className?: string;
}

const MainNavLink = ({ href, children, className = '' }: MainNavLinkProps) => {
	return (
		<NavigationMenuLink asChild>
			<Link
				href={href}
				className={cn(
					className,
					`rounded-full px-4 py-2 text-[0.9rem] transition
					duration-200 hover:bg-gray-200 hover:text-black`,
				)}
			>
				{children}
			</Link>
		</NavigationMenuLink>
	);
};

export default MainNavLink;
