const ROOT_URL = '/';
const AUTH_PATH = ROOT_URL + 'auth';

function route(page: string) {
	return ROOT_URL + `${page}`;
}

function authRoute(page: string) {
	return AUTH_PATH + `/${page}`;
}

export const ROUTE_PATHS = {
	home: ROOT_URL,
	services: route('services'),
	about: route('about'),
	auth: {
		register: authRoute('register'),
		login: authRoute('login'),
	},
};
