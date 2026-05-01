import { EnvVarsNotFound } from '../errors';

abstract class BaseConfig {
	protected static getNonNullableVar(varName: string) {
		const variable = this.getEnv(varName);

		if (variable === undefined) {
			throw new EnvVarsNotFound({
				envVarName: varName,
			});
		}

		return variable;
	}

	protected static getEnv(varName: string) {
		return process.env[varName];
	}
}

export default BaseConfig;
