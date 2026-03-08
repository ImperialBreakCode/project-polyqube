import { ReactNode } from 'react';
import { AlertCircleIcon } from 'lucide-react';
import { Alert, AlertDescription, AlertTitle } from './ui/Alert';
import { cn } from '../lib/utils';

interface ErrorAlertProps {
	children: ReactNode;
	title: string;
	className?: string;
}

const ErrorAlert = ({ children, title, className }: ErrorAlertProps) => {
	return (
		<Alert variant='destructive' className={cn('max-w-md', className)}>
			<AlertCircleIcon size={20} />
			<AlertTitle>{title}</AlertTitle>
			<AlertDescription>{children}</AlertDescription>
		</Alert>
	);
};

export default ErrorAlert;
