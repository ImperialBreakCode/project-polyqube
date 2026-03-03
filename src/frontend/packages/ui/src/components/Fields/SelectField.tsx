import {
	Select,
	SelectContent,
	SelectGroup,
	SelectItem,
	SelectTrigger,
	SelectValue,
} from '../ui/Select';

export type SelectFieldValue = {
	value: string;
	label: string;
};

interface SelectFieldProps {
	values: SelectFieldValue[];
	placeholder?: string;
	'aria-invalid'?: boolean | 'true' | 'false' | 'grammar' | 'spelling';
	className?: string;
	value?: string;
	onChange: (value: string) => void;
}

const SelectField = ({
	values,
	placeholder,
	'aria-invalid': ariaInvalid,
	className,
	value,
	onChange,
}: SelectFieldProps) => {
	return (
		<Select value={value} onValueChange={onChange}>
			<SelectTrigger className={className} aria-invalid={ariaInvalid}>
				<SelectValue placeholder={placeholder} />
			</SelectTrigger>
			<SelectContent>
				<SelectGroup>
					{values.map((x) => (
						<SelectItem key={x.value} value={x.value}>
							{x.label}
						</SelectItem>
					))}
				</SelectGroup>
			</SelectContent>
		</Select>
	);
};

export default SelectField;
