'use client';

import { useState } from 'react';
import { EyeIcon, EyeOffIcon } from 'lucide-react';
import { Input } from '../ui/Input';
import { BasicInputFieldProps } from './types';

const PasswordField = (props: BasicInputFieldProps) => {
	const [isVisible, setIsVisible] = useState(false);

	return (
		<div className='relative'>
			<Input {...props} type={isVisible ? 'text' : 'password'} />
			<button
				type='button'
				onClick={() => setIsVisible((prevState) => !prevState)}
				className='text-muted-foreground absolute top-1/2
					-translate-y-1/2 right-2 hover:bg-[#ffffff26] rounded p-1'
			>
				{isVisible ? <EyeOffIcon size={17} /> : <EyeIcon size={17} />}
				<span className='sr-only'>
					{isVisible ? 'Hide password' : 'Show password'}
				</span>
			</button>
		</div>
	);
};

export default PasswordField;
