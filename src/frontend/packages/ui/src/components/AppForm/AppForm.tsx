'use client';

import { ReactNode, useCallback } from 'react';
import {
	DefaultValues,
	FieldValues,
	FormProvider,
	SubmitErrorHandler,
	SubmitHandler,
	useForm,
	UseFormProps,
} from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { ZodType } from 'zod';
import { ExtendedFormContext } from './types';

function generateFormId(formName: string) {
	return `form-${formName}`;
}

interface AppFormProps<T extends FieldValues> {
	children: ReactNode;
	name: string;
	schema: ZodType<T>;
	onSubmit: SubmitHandler<T>;
	onError?: SubmitErrorHandler<T>;
	values?: T;
	//errors?
	defaultValues?: DefaultValues<T>;
	mode?: UseFormProps<T>['mode'];
	//className?: string;
	resetAfterSubmit?: boolean;
}

const AppForm = <T extends FieldValues>({
	children,
	name,
	onSubmit,
	onError,
	mode = 'onSubmit',
	schema,
	defaultValues,
	values,
	resetAfterSubmit = true,
}: AppFormProps<T>) => {
	const id = generateFormId(name);

	const form = useForm<T>({
		mode,
		defaultValues,
		values,
		// zodResolver uses zod 3 and the installed zod is v4
		// zodResolver with zod 4 is still not available
		// eslint-disable-next-line @typescript-eslint/no-explicit-any
		resolver: (zodResolver as any)(schema),
	});

	const onSubmitHandler = useCallback<SubmitHandler<T>>(
		(data, event) => {
			event?.preventDefault();
			event?.stopPropagation();
			onSubmit(data, event);
			if (resetAfterSubmit) {
				form.reset(defaultValues);
			}
		},
		[onSubmit, defaultValues, form, resetAfterSubmit],
	);

	const extendedForm: ExtendedFormContext<T> = {
		...form,
		formId: id,
	};

	return (
		<FormProvider {...extendedForm}>
			<form
				id={id}
				onSubmit={(e) => {
					e.stopPropagation();
					form.handleSubmit(onSubmitHandler, onError)(e);
				}}
			>
				{children}
			</form>
		</FormProvider>
	);
};

export default AppForm;
