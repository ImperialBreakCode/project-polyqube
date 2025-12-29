import { config as base } from "./base.js";

/**
 * @type {import("prettier").Options}
 */
export const nextConfig = {
	...base,
	plugins: ["prettier-plugin-tailwindcss", "prettier-plugin-classnames"],
	jsxSingleQuote: true,
	endingPosition: "absolute",
};
