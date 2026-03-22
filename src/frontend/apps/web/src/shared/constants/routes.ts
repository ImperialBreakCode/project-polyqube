const ROOT_URL = '/';
const AUTH_PATH = ROOT_URL + 'auth';
const SETUP_PATH = ROOT_URL + 'setup';
const USER_PANEL_PATH = ROOT_URL + 'user-panel';

function route(page: string) {
	return ROOT_URL + `${page}`;
}

function authRoute(page: string) {
	return AUTH_PATH + `/${page}`;
}

function setupRoute(page: string) {
	return SETUP_PATH + `/${page}`;
}

function userPanelRoute(page: string) {
	return USER_PANEL_PATH + `/${page}`;
}

export const ROUTE_PATHS = {
	home: ROOT_URL,
	services: route('services'),
	about: route('about'),
	auth: {
		register: authRoute('register'),
		login: authRoute('login'),
	},
	userPanel: {
		homeDashboard: USER_PANEL_PATH,
		personalInfo: userPanelRoute('personal-info'),
	},
	infoPanels: {
		userRegistered: route('user-registered'),
		verifyEmail: route('verify-email'),
	},
	setup: {
		userDetails: setupRoute('user-details'),
		profilePicture: setupRoute('profile-picture'),
	},
};
