import { config as base } from "./base.js";

/**
 * @type {import("prettier").Options}
 */
export const nextConfig = {
	plugins: ["prettier-plugin-tailwindcss"],
	...base,
	jsxSingleQuote: true,
};
