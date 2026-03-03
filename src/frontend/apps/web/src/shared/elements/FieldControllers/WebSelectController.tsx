import SelectController, {
	SelectControllerProps,
} from '@repo/ui/components/AppForm/FieldControllers/SelectController';

type WebSelectControllerProps = SelectControllerProps;

const WebSelectController = (props: WebSelectControllerProps) => {
	return <SelectController {...props} />;
};

export default WebSelectController;
