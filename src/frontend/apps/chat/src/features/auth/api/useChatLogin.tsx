import { chatLoginRequest } from '@/server';
import useApi from '@repo/ui/hooks/api/useApi';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

function useChatLogin(code: string) {
	const { loading, statusCode } = useApi(chatLoginRequest, {
		requestOnInit: true,
		initRequestData: {
			code,
		},
	});

	return {
		loading,
		success: statusCode === STATUS_CODES.ok,
	};
}

export default useChatLogin;
