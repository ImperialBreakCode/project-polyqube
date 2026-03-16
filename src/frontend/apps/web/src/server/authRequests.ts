'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { STATUS_CODES } from '@/shared/constants/statusCodes';
import {
	deleteAccessTokenCookie,
	deleteRefreshTokenCookie,
	FetchServerReturnType,
	serverRequest,
	setAccessTokenCookie,
	setRefreshTokenCookie,
} from './base';

const AUTH_CONTROLLER = `${ACCOUNT_SERVICE_ROUTE}/auth`;

type LoginUserRequestDTO = {
	username: string;
	password: string;
};

type LoginResponseDTO = {
	accessToken: string;
	refreshToken: string;
};

export async function loginRequest(
	body: LoginUserRequestDTO,
): Promise<FetchServerReturnType<null>> {
	const {
		body: responseBody,
		error,
		problemResponse,
		statusCode,
	} = await serverRequest<LoginResponseDTO, LoginUserRequestDTO>(
		`${AUTH_CONTROLLER}/login`,
		{
			method: 'POST',
			requestWithAuth: false,
			body,
		},
	);

	if (statusCode === STATUS_CODES.ok && responseBody) {
		await setAccessTokenCookie(responseBody.accessToken);
		await setRefreshTokenCookie(responseBody.refreshToken);
	}

	return {
		body: null,
		error,
		problemResponse,
		statusCode,
	};
}

export async function logoutRequest(): Promise<FetchServerReturnType<null>> {
	const response = await serverRequest<null, null>(
		`${AUTH_CONTROLLER}/logout`,
		{
			method: 'DELETE',
			requestWithAuth: true,
			body: null,
		},
	);

	await deleteAccessTokenCookie();
	await deleteRefreshTokenCookie();

	return {
		...response,
	};
}
