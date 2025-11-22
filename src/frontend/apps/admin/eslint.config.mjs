import { defineConfig } from 'eslint/config';

import { nextJsConfig as globalNextJsConfig } from '@repo/eslint-config/next-js';

const eslintConfig = defineConfig([...globalNextJsConfig]);

export default eslintConfig;
