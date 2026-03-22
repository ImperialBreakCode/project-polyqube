import { ReactNode } from 'react';
import { ControllerFieldState } from 'react-hook-form';
import { Field, FieldError, FieldLabel } from '@repo/ui/components/ui/Field';

interface BasicFieldWrapperProps {
	labelText: string;
	fieldState: ControllerFieldState;
	children: ReactNode;
	htmlFor?: string;
	className?: string;
}

const BasicFieldWrapper = ({
	children,
	fieldState,
	htmlFor,
	labelText,
	className = '',
}: BasicFieldWrapperProps) => {
	return (
		<Field className={className} data-invalid={fieldState.invalid}>
			<FieldLabel htmlFor={htmlFor}>{labelText}</FieldLabel>
			{children}
			{fieldState.invalid && <FieldError errors={[fieldState.error]} />}
		</Field>
	);
};

export default BasicFieldWrapper;
