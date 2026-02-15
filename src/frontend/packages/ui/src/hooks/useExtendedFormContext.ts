import { useFormContext } from 'react-hook-form';
import { ExtendedFormContext } from '@repo/ui/components/AppForm/types';

const useExtendedFormContext = <T extends Record<string, unknown>>() => {
	const context = useFormContext<T>() as ExtendedFormContext<T>;

	if (context === undefined) {
		throw new Error(
			'useExtendedFormContext must be used within a FormProvider',
		);
	}

	return context;
};

export default useExtendedFormContext;
