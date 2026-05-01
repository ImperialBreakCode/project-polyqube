import BaseConfig from './BaseConfig';

class UtilsConfig extends BaseConfig {
	constructor() {
		super();
	}

	public static get apiHost(): string {
		return this.getNonNullableVar('API_BASE_HOST');
	}

	public static get chatAppHost(): string {
		return this.getNonNullableVar('CHAT_APP_HOST');
	}
}

export default UtilsConfig;
