import DatePickerController, {
	DatePickerControllerProps,
} from '@repo/ui/components/AppForm/FieldControllers/DatePickerController';

type WebDateControllerProps = Omit<
	DatePickerControllerProps,
	'datePickerClassName'
>;

const WebDateController = (props: WebDateControllerProps) => {
	const className = '';

	return <DatePickerController {...props} datePickerClassName={className} />;
};

export default WebDateController;
