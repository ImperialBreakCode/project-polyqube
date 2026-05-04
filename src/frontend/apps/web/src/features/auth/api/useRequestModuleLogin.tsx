'use client';

import { requestModuleLogin } from '@/server/authRequests';
import useApi from '@repo/ui/hooks/api/useApi';
import { useAuthWrapper } from '@/shared/hooks';

function useRequestModuleLogin(moduleName: string) {
	const { loading, data, statusCode } = useAuthWrapper(
		useApi(requestModuleLogin, {
			initRequestData: {
				moduleName,
			},
			requestOnInit: true,
		}),
	);

	return {
		loading,
		code: data?.code,
		statusCode,
	};
}

export default useRequestModuleLogin;
