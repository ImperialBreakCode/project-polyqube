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
			className = `bg-(--primary-color) border border-b-(--border-pirmary) border-l-(--border-pirmary) border-t-(--border-primary-2) border-r-(--border-primary-2)
				text-white hover:bg-(--primary-hover) cursor-pointer`;
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
