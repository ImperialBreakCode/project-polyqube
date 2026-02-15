import { UseFormReturn } from 'react-hook-form';

export type ExtendedFormContext<T extends Record<string, unknown>> =
	UseFormReturn<T> & {
		formId: string;
	};
