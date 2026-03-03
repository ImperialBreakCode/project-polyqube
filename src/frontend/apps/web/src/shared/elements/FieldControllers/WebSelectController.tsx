import SelectController, {
	SelectControllerProps,
} from '@repo/ui/components/AppForm/FieldControllers/SelectController';
import { cn } from '@repo/ui/lib/utils';
import { webAppFieldClassName } from './styles';

type WebSelectControllerProps = Omit<SelectControllerProps, 'selectClassName'>;

const WebSelectController = (props: WebSelectControllerProps) => {
	return (
		<SelectController
			{...props}
			selectClassName={cn(webAppFieldClassName, 'cursor-pointer')}
		/>
	);
};

export default WebSelectController;
