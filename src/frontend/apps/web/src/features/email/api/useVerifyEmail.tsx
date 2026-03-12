import { verifyEmailRequest } from '@/server/userRequests';
import { STATUS_CODES } from '@/shared/constants/statusCodes';
import useApi from '@/shared/hooks/useApi';

function useVerifyEmail({
	emailVerificationToken,
}: {
	emailVerificationToken: string;
}) {
	const { loading, statusCode } = useApi(verifyEmailRequest, {
		requestOnInit: true,
		initRequestData: {
			emailVerificationToken,
		},
	});

	return {
		loading,
		success: statusCode === STATUS_CODES.ok,
	};
}

export default useVerifyEmail;
