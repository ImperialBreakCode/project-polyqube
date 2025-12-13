import { ReactNode } from 'react';

function LandingLayout({ children }: { children: ReactNode }) {
	return (
		<div>
			<header></header>
			<main>{children}</main>
		</div>
	);
}

export default LandingLayout;
