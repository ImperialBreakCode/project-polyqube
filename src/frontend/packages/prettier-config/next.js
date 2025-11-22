import { config as base } from "./base.js";

/**
 * @type {import("prettier").default.Options}
 */
export const nextConfig = {
	...base,
	plugins: ["prettier-plugin-tailwindcss"],
	jsxSingleQuote: true,
};
