'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

const USER_CONTROLLER = `${ACCOUNT_SERVICE_ROUTE}/users`;

type RegisterUserRequestDTO = {
	username: string;
	email: string;
	password: string;
};

export async function registerRequest(body: RegisterUserRequestDTO) {
	return await serverRequest<null, RegisterUserRequestDTO>(
		`${USER_CONTROLLER}/register`,
		{
			method: 'POST',
			requestWithAuth: false,
			body,
		},
	);
}

type VerifyEmailRequestDTO = {
	emailVerificationToken: string;
};

export async function verifyEmailRequest(body: VerifyEmailRequestDTO) {
	return await serverRequest<null, VerifyEmailRequestDTO>(
		`${USER_CONTROLLER}/verify-email`,
		{
			method: 'POST',
			requestWithAuth: false,
			body,
		},
	);
}
