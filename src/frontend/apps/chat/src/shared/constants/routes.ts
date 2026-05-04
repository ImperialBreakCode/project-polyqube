const ROOT_URL = '/';

function route(page: string) {
	return ROOT_URL + `${page}`;
}

export const ROUTE_PATHS = {
	home: ROOT_URL,
	chatLogin: route('login'),
};
