'use client';

import { createContext } from 'react';

export interface SessionState {
	authState: 'guest' | 'forSetup' | 'loggedIn';
}

export interface SessionContextValues {
	state: SessionState;
	updateSession: () => Promise<void>;
}

export const SessionContext = createContext<SessionContextValues>({
	state: {
		authState: 'guest',
	},
	updateSession: async () => {},
});
