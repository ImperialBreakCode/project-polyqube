import turboPlugin from "eslint-plugin-turbo";
import eslintConfigPrettier from "eslint-config-prettier";

/**
 * A shared ESLint configuration for the repository.
 *
 * @type {import("eslint").Linter.Config[]}
 * */
export const config = [
	eslintConfigPrettier,
	{
		plugins: {
			turbo: turboPlugin,
		},
		rules: {
			"turbo/no-undeclared-env-vars": "warn",
		},
	},
	{
		ignores: ["dist/**"],
	},
];
