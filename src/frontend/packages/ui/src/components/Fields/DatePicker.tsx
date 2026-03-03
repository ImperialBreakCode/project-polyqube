import { useState } from 'react';
import { DayPicker } from 'react-day-picker';
import { Popover, PopoverContent, PopoverTrigger } from '../ui/Popover';
import { Button } from '../ui/Button';
import { Calendar } from '../ui/Calendar';
import { cn } from '@repo/ui/lib/utils';

interface DatePickerProps {
	className?: string;
	classNames?: React.ComponentProps<typeof DayPicker>['classNames'];
}

const DatePicker = ({ className, classNames }: DatePickerProps) => {
	const [open, setOpen] = useState(false);
	const [date, setDate] = useState<Date | undefined>(undefined);
	return (
		<Popover open={open} onOpenChange={setOpen}>
			<PopoverTrigger asChild>
				<Button
					variant='outline'
					id='date'
					className={cn('justify-start font-normal', className)}
				>
					{date ? date.toLocaleDateString() : 'Select date'}
				</Button>
			</PopoverTrigger>
			<PopoverContent
				className='w-auto overflow-hidden p-0'
				align='start'
			>
				<Calendar
					mode='single'
					selected={date}
					defaultMonth={date}
					captionLayout='dropdown'
					classNames={classNames}
					onSelect={(date) => {
						setDate(date);
						setOpen(false);
					}}
				/>
			</PopoverContent>
		</Popover>
	);
};

export default DatePicker;
