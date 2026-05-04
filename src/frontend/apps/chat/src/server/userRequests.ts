'use server';

import { CHAT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { serverRequest } from './base';

const USER_PROFILE_CONTROLLER = `${CHAT_SERVICE_ROUTE}/user-profiles`;

export type UserProfileResponseDTO = {
	id: string;
	userId: string;
	firstName: string;
	lastName: string;
	profilePicture: string;
	lockedOut: boolean;
	disabled: boolean;
	suspended: boolean;
	createdAt: string;
	updatedAt: string;
	deletedAt: string;
};

export async function getCurrentUserRequest() {
	return await serverRequest<UserProfileResponseDTO, null>(
		`${USER_PROFILE_CONTROLLER}/get-current-profile`,
		{
			method: 'GET',
			requestWithAuth: true,
			body: null,
		},
	);
}
