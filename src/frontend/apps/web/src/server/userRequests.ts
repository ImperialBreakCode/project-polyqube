'use server';

import { ACCOUNT_SERVICE_ROUTE } from '@repo/utils/constants/apiRoutes';
import { GenderEnum } from '@/shared/constants/genderEnum';
import { serverRequest } from './base';

const USER_CONTROLLER = `${ACCOUNT_SERVICE_ROUTE}/users`;

// Responses
export interface UserEmailResponseDTO {
	email: string;
	isPrimary: boolean;
	isVerified: boolean;
	createdAt: string; // ISO string for DateTime
	updatedAt: string; // ISO string for DateTime
}

export interface UserDetailsResponseDTO {
	firstName: string;
	lastName: string;
	birthdate: string; // DateOnly as ISO date string (YYYY-MM-DD)
	gender: GenderEnum;
	profilePicturePath?: string;
	createdAt: string; // ISO string
	updatedAt: string; // ISO string
}

export interface UserResponseDTO {
	id: string;
	username: string;
	lockedOut: boolean;
	disabled: boolean;
	suspended: boolean;
	emails: UserEmailResponseDTO[];
	userDetails?: UserDetailsResponseDTO;
	createdAt: string; // ISO string
	updatedAt: string; // ISO string
}

// Requests and request DTOs

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

export async function getCurrentUserRequest() {
	return await serverRequest<UserResponseDTO, null>(
		`${USER_CONTROLLER}/get-current-user`,
		{
			requestWithAuth: true,
			body: null,
		},
	);
}

export type CreateUserDetailsRequestDTO = {
	firstName: string;
	lastName: string;
	birthdate: string;
	gender: GenderEnum;
};

export async function createUserDetailsRequest(
	body: CreateUserDetailsRequestDTO,
) {
	return await serverRequest<UserResponseDTO, CreateUserDetailsRequestDTO>(
		`${USER_CONTROLLER}/create-user-details`,
		{
			method: 'POST',
			requestWithAuth: true,
			body,
		},
	);
}
