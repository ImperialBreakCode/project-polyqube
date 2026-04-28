'use client';

import { FieldValues } from 'react-hook-form';
import EmailField from '@repo/ui/components/Fields/EmailField';
import createBasicController, {
	BasicControllerProps,
} from './createBasicController';

export default function EmailFieldController<T extends FieldValues>(
	props: BasicControllerProps<T>,
) {
	const Controller = createBasicController(EmailField);
	return <Controller {...props} />;
}
