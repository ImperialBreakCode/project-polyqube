'use client';

import { useState } from 'react';
import { Noop } from 'react-hook-form';
import { DayPicker } from 'react-day-picker';
import { ChevronDownIcon } from 'lucide-react';
import { Popover, PopoverContent, PopoverTrigger } from '../ui/Popover';
import { Button } from '../ui/Button';
import { Calendar } from '../ui/Calendar';
import { cn } from '@repo/ui/lib/utils';

interface DatePickerProps {
	id?: string;
	className?: string;
	classNames?: React.ComponentProps<typeof DayPicker>['classNames'];
	disabled?: boolean;
	onChange?: (value: Date | undefined) => void;
	value?: Date;
	onBlur?: Noop;
	placeholder?: string;
	'aria-invalid': boolean | 'true' | 'false' | 'grammar' | 'spelling';
}

const DatePicker = ({
	className,
	classNames,
	id,
	disabled = false,
	onChange,
	value,
	onBlur,
	placeholder,
	'aria-invalid': ariaInvalid,
}: DatePickerProps) => {
	const [open, setOpen] = useState(false);

	return (
		<Popover
			open={open}
			onOpenChange={(val) => {
				if (!val && onBlur) {
					onBlur();
				}

				setOpen(val);
			}}
		>
			<PopoverTrigger asChild>
				<Button
					variant='outline'
					id={id}
					className={cn(
						'justify-between',
						value
							? ''
							: `text-muted-foreground
								hover:text-muted-foreground`,
						className,
					)}
					disabled={disabled}
					aria-invalid={ariaInvalid}
				>
					{value
						? value.toLocaleDateString()
						: (placeholder ?? 'Select date')}

					<ChevronDownIcon />
				</Button>
			</PopoverTrigger>
			<PopoverContent
				className='w-auto overflow-hidden p-0'
				align='start'
			>
				<Calendar
					mode='single'
					selected={value}
					defaultMonth={value}
					captionLayout='dropdown'
					classNames={classNames}
					onSelect={(date) => {
						onChange?.(date);
						setOpen(false);
					}}
					disabled={disabled}
				/>
			</PopoverContent>
		</Popover>
	);
};

export default DatePicker;
