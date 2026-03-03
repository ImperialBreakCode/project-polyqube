import { Controller, useFormContext } from 'react-hook-form';
import { BasicFieldWrapper } from '../FieldWrappers';
import { SelectField, SelectValue } from '../../Fields';

export interface SelectControllerProps {
	name: string;
	label: string;
	values: SelectValue[];
	className?: string;
	placeholder?: string;
	selectClassName?: string;
}

const SelectController = ({
	name,
	label,
	className,
	placeholder,
	values,
	selectClassName,
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
						className={selectClassName}
					/>
				</BasicFieldWrapper>
			)}
		/>
	);
};

export default SelectController;
