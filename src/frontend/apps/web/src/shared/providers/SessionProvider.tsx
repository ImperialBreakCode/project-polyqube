'use client';

import { ReactNode, useEffect } from 'react';
import { usePathname, useRouter } from 'next/navigation';
import { SessionContext } from '../contexts';
import { useSessionState } from '../api';
import { ROUTE_PATHS } from '../constants/routes';

function SessionProvider({ children }: { children: ReactNode }) {
	const pathname = usePathname();
	const router = useRouter();
	const { state, updateSession } = useSessionState();

	useEffect(() => {
		if (
			state.authState === 'forSetup' &&
			pathname !== ROUTE_PATHS.setup.userDetails
		) {
			router.push(ROUTE_PATHS.setup.userDetails);
		}
	}, [pathname, state, router]);

	return (
		<SessionContext.Provider
			value={{
				state,
				updateSession,
			}}
		>
			{children}
		</SessionContext.Provider>
	);
}

export default SessionProvider;
