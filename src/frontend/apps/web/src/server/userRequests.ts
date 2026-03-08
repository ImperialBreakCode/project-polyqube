'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

const USER_CONTROLLER = `${ACCOUNT_SERVICE_ROUTE}/user`;

type RegisterUserRequestDTO = {
	username: string;
	email: string;
	password: string;
};

export function registerRequest() {
	return serverRequest<null, RegisterUserRequestDTO>(
		`${USER_CONTROLLER}/register`,
		{
			method: 'POST',
		},
	);
}
