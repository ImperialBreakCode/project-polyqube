import { Button, ButtonProps } from '@repo/ui/core';

const AppButton = ({ children, ...props }: ButtonProps) => {
	return <Button {...props}>{children}</Button>;
};

export default AppButton;
