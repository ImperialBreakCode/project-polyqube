'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { FetchServerReturnType } from '@repo/utils/server/baseFetch';
import { getTokenService, serverRequest } from './base';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

const AUTH_CONTROLLER = `${ACCOUNT_SERVICE_ROUTE}/auth`;

type ModuleLoginRequestDTO = {
	code: string;
};

type LoginResponseDTO = {
	accessToken: string;
	refreshToken: string;
};

export async function chatLoginRequest(
	body: ModuleLoginRequestDTO,
): Promise<FetchServerReturnType<null>> {
	const { setAccessTokenCookie, setRefreshTokenCookie } =
		await getTokenService();

	const {
		body: responseBody,
		error,
		problemResponse,
		statusCode,
	} = await serverRequest<LoginResponseDTO, ModuleLoginRequestDTO>(
		`${AUTH_CONTROLLER}/module-login`,
		{
			method: 'POST',
			requestWithAuth: true,
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
