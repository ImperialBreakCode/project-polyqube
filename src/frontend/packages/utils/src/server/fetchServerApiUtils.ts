import { UtilsConfig } from '../utilConfig';

export type MethodTypes = 'GET' | 'POST' | 'PUT' | 'DELETE';
export type UrlInput = string | URL;

export const getServerRoute = (route: UrlInput) =>
	new URL(UtilsConfig.apiHost, route);
