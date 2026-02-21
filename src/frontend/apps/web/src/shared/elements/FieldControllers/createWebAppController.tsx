import { FieldValues } from 'react-hook-form';
import { BasicControllerProps } from '@repo/ui/components/AppForm/FieldControllers/createBasicController';
import { cn } from '@repo/ui/lib/utils';
import { webAppFieldClassName } from './styles';

const createWebAppController = <T extends FieldValues>(
	BaseController: React.ComponentType<BasicControllerProps<T>>,
) =>
	function WebAppController({
		fieldClassName,
		...props
	}: BasicControllerProps<T>) {
		return (
			<BaseController
				fieldClassName={cn(fieldClassName, webAppFieldClassName)}
				{...props}
			/>
		);
	};

export default createWebAppController;
