import { Controller, FieldValues, Path } from 'react-hook-form';
import { BasicInputFieldProps } from '@repo/ui/components/Fields/types';
import BasicFieldWrapper from '@repo/ui/components/AppForm/FieldWrappers/BasicFieldWrapper';
import useExtendedAppFormContext from '../../../hooks/useExtendedAppFormContext';
import { generateControllerId } from './utils';

export interface BasicControllerProps<T extends FieldValues> {
	name: Path<T>;
	label: string;
	placeholder?: string;
	className?: string;
	fieldClassName?: string;
	disabled?: boolean;
}

const createBasicController = (
	BasicInputField: React.ComponentType<BasicInputFieldProps>,
) =>
	function BasicController<T extends FieldValues>({
		name,
		label,
		className,
		fieldClassName,
		placeholder,
		disabled,
	}: BasicControllerProps<T>) {
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
						<BasicInputField
							{...field}
							id={id}
							className={fieldClassName}
							aria-invalid={fieldState.invalid}
							placeholder={placeholder}
							disabled={disabled ?? field.disabled}
						/>
					</BasicFieldWrapper>
				)}
			/>
		);
	};

export default createBasicController;
