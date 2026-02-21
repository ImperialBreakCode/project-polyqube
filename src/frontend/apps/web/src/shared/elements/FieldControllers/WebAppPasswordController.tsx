import PasswordFieldController from '@repo/ui/components/AppForm/FieldControllers/PasswordFieldController';
import createWebAppController from './createWebAppController';

const WebAppPasswordController = createWebAppController(
	PasswordFieldController,
);

export default WebAppPasswordController;
