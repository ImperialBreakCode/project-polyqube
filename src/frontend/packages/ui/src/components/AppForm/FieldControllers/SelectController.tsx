import { Controller, useFormContext } from 'react-hook-form';
import { BasicFieldWrapper } from '../FieldWrappers';
import { SelectField, SelectValue } from '../../Fields';

export interface SelectControllerProps {
	name: string;
	label: string;
	values: SelectValue[];
	className?: string;
	placeholder?: string;
}

const SelectController = ({
	name,
	label,
	className,
	placeholder,
	values,
}: SelectControllerProps) => {
	const { control } = useFormContext();

	return (
		<Controller
			name={name}
			control={control}
			render={({ field, fieldState }) => (
				<BasicFieldWrapper
					className={className}
					fieldState={fieldState}
					labelText={label}
				>
					<SelectField
						{...field}
						aria-invalid={fieldState.invalid}
						placeholder={placeholder}
						values={values}
					/>
				</BasicFieldWrapper>
			)}
		/>
	);
};

export default SelectController;
