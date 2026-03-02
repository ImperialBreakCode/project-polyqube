import { Button, ButtonProps } from '@repo/ui/core';
import { cn } from '@repo/ui/lib/utils';

const AppButton = ({
	children,
	className: customClassname,
	variant = 'default',
	...props
}: ButtonProps) => {
	let className = '';

	switch (variant) {
		case 'default':
			className = `border button-primary-colors cursor-pointer`;
			break;
	}

	return (
		<Button
			className={cn(className, 'px-6 py-5', customClassname)}
			variant={variant}
			{...props}
		>
			{children}
		</Button>
	);
};

export default AppButton;
