'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { STATUS_CODES } from '@/shared/constants/statusCodes';
import { getTokenService, serverRequest } from './base';
import { FetchServerReturnType } from '@repo/utils/server/baseFetch';

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
	const { setAccessTokenCookie, setRefreshTokenCookie } =
		await getTokenService();

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

type RequestModuleLoginBody = {
	moduleName: string;
};

type ModuleAccessRequestDTO = {
	accessToken: string;
	refreshToken: string;
	moduleName: string;
};

type ModuleAccessResponseDTO = {
	code: string;
	expiration: string;
};

export async function requestModuleLogin(
	body: RequestModuleLoginBody,
): Promise<FetchServerReturnType<ModuleAccessResponseDTO>> {
	const { getAccessTokenCookie, getRefreshTokenCookie } =
		await getTokenService();

	const accessToken = (await getAccessTokenCookie())?.value;
	const refreshToken = (await getRefreshTokenCookie())?.value;

	const request: ModuleAccessRequestDTO = {
		accessToken: accessToken ?? '',
		refreshToken: refreshToken ?? '',
		moduleName: body.moduleName,
	};

	const response = await serverRequest<
		ModuleAccessResponseDTO,
		ModuleAccessRequestDTO
	>(`${AUTH_CONTROLLER}/request-module-access`, {
		method: 'POST',
		requestWithAuth: true,
		body: request,
	});

	return response;
}

export async function logoutRequest(): Promise<FetchServerReturnType<null>> {
	const { deleteAccessTokenCookie, deleteRefreshTokenCookie } =
		await getTokenService();

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
