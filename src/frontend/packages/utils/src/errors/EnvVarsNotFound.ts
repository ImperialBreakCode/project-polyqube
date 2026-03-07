import AppError from './AppError';

type EnvVarsNotFoundOptions = {
	message?: string;
	envVarName: string;
};

class EnvVarsNotFound extends AppError {
	public envVarName: string;

	constructor({ envVarName, message }: EnvVarsNotFoundOptions) {
		super(message ?? 'Env var not found.');

		this.envVarName = envVarName;
	}
}

export default EnvVarsNotFound;
