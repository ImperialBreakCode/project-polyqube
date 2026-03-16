'use client';

import { ReactNode, useCallback, useEffect } from 'react';
import { usePathname, useRouter } from 'next/navigation';
import { checkForRefreshToken } from '@/server/utilServerFunctions';
import { SessionContext } from '../contexts';
import { useSessionState } from '../api';
import { ROUTE_PATHS } from '../constants/routes';

function SessionProvider({ children }: { children: ReactNode }) {
	const pathname = usePathname();
	const router = useRouter();
	const { state, updateSession } = useSessionState();

	const checkForExpiredRefreshToken = useCallback(async () => {
		const result = await checkForRefreshToken();

		if (!result && state.authState !== 'guest') {
			await updateSession();
		}
	}, [updateSession, state.authState]);

	useEffect(() => {
		if (
			state.authState === 'forSetup' &&
			pathname !== ROUTE_PATHS.setup.userDetails
		) {
			router.push(ROUTE_PATHS.setup.userDetails);
		}
	}, [pathname, state, router]);

	useEffect(() => {
		checkForExpiredRefreshToken();
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [pathname]);

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
