import type { Meta, StoryObj } from '@storybook/nextjs-vite';
import { ButtonProps } from '@repo/ui/core';
import AppButton from './AppButton';

const meta: Meta<ButtonProps> = {
	title: 'AppButton',
	component: AppButton,
	parameters: {
		layout: 'centered',
	},
	tags: ['autodocs'],
	argTypes: {
		children: { control: 'text' },
	},
};

export default meta;

type Story = StoryObj<typeof meta>;

export const Primary: Story = {
	args: {
		children: 'Click Me',
		variant: 'default',
		disabled: false,
	},
};

export const Outline: Story = {
	args: {
		children: 'Click Me',
		variant: 'outline',
		disabled: false,
	},
};
