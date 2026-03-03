import DatePickerController, {
	DatePickerControllerProps,
} from '@repo/ui/components/AppForm/FieldControllers/DatePickerController';
import { webAppFieldClassName } from './styles';
import { cn } from '@repo/ui/lib/utils';

type WebDateControllerProps = Omit<
	DatePickerControllerProps,
	'datePickerClassName'
>;

const WebDateController = (props: WebDateControllerProps) => {
	return (
		<DatePickerController
			{...props}
			datePickerClassName={cn(webAppFieldClassName, 'cursor-pointer')}
		/>
	);
};

export default WebDateController;
