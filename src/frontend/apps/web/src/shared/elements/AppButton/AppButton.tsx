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
			className = `border button-primary-colors`;
			break;
		default:
			className = 'border border-[#444444]';
			break;
	}

	return (
		<Button
			className={cn(
				className,
				'px-6 py-5 cursor-pointer',
				customClassname,
			)}
			variant={variant}
			{...props}
		>
			{children}
		</Button>
	);
};

export default AppButton;
