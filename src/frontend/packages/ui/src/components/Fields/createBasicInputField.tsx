import { Input } from '../ui/Input';
import { BasicInputFieldProps } from './type';

function createBasicInputField(
	type: React.ComponentProps<typeof Input>['type'],
) {
	const InputComponent = ({ ...props }: BasicInputFieldProps) => {
		return <Input type={type} {...props} />;
	};
	return InputComponent;
}

export default createBasicInputField;
