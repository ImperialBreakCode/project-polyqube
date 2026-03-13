import { UtilsConfig } from '../utilConfig';

export type MethodTypes = 'GET' | 'POST' | 'PUT' | 'DELETE';

export type ApiServerProblemResponse = {
	title: string;
	detail: string;
	type: string;
	status: number;
	errors?: { [key: string]: string[] };
};

export const getServerRoute = (route: string) =>
	`${UtilsConfig.apiHost}${route}`;
