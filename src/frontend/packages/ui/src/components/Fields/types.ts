import { Input } from '../ui/Input';

export type BasicInputFieldProps = Omit<
	React.ComponentProps<typeof Input>,
	'type'
>;
