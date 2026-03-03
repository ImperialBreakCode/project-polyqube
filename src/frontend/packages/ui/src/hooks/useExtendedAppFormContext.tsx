'use client';

import { useContext } from 'react';
import { useFormContext } from 'react-hook-form';
import { AppFormContext } from '../components';

const useExtendedAppFormContext = () => {
	const appFormContext = useContext(AppFormContext);
	const formContext = useFormContext();

	return { ...appFormContext, ...formContext };
};

export default useExtendedAppFormContext;
