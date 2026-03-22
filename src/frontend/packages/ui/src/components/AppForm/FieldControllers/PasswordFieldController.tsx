'use client';

import { Controller, FieldValues } from 'react-hook-form';
import useExtendedAppFormContext from '../../../hooks/useExtendedAppFormContext';
import { cn } from '@repo/ui/lib/utils';
import { BasicFieldWrapper } from '../FieldWrappers';
import { PasswordField } from '../../Fields';
import { BasicControllerProps } from './createBasicController';
import { generateControllerId } from './utils';

const PasswordFieldController = <T extends FieldValues>({
	name,
	label,
	placeholder,
	className,
	fieldClassName,
	disabled = false,
}: BasicControllerProps<T>) => {
	const { formId, control } = useExtendedAppFormContext();
	const id = generateControllerId(formId, name);

	return (
		<Controller
			name={name}
			control={control}
			render={({ field, fieldState }) => (
				<BasicFieldWrapper
					className={className}
					htmlFor={id}
					fieldState={fieldState}
					labelText={label}
				>
					<PasswordField
						{...field}
						id={id}
						className={cn(fieldClassName, 'pr-2')}
						aria-invalid={fieldState.invalid}
						placeholder={placeholder}
						disabled={disabled ?? field.disabled}
					/>
				</BasicFieldWrapper>
			)}
		/>
	);
};

export default PasswordFieldController;
