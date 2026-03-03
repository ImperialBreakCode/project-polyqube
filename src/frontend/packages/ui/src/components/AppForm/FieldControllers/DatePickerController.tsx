'use client';

import { Controller } from 'react-hook-form';
import { useExtendedAppFormContext } from '../../../hooks';
import { BasicFieldWrapper } from '../FieldWrappers';
import DatePicker from '../../Fields/DatePicker';
import { generateControllerId } from './utils';

interface DatePickerControllerProps {
	label: string;
	name: string;
	className?: string;
	datePickerClassName?: string;
	placeholder?: string;
}

const DatePickerController = ({
	label,
	name,
	className,
	datePickerClassName,
	placeholder,
}: DatePickerControllerProps) => {
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
					<DatePicker
						{...field}
						id={id}
						className={datePickerClassName}
						aria-invalid={fieldState.invalid}
						placeholder={placeholder}
					/>
				</BasicFieldWrapper>
			)}
		/>
	);
};

export default DatePickerController;
