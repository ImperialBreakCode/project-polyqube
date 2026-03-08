import { UtilsConfig } from '../utilConfig';

export type MethodTypes = 'GET' | 'POST' | 'PUT' | 'DELETE';
export type UrlInput = string | URL;

export type ApiServerProblemResponse = {
	title: string;
	detail: string;
	type: string;
	status: number;
	errors?: { [key: string]: string[] };
};

export const getServerRoute = (route: UrlInput) =>
	new URL(UtilsConfig.apiHost, route);
