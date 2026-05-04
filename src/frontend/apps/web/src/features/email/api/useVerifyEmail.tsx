import { verifyEmailRequest } from '@/server/userRequests';
import useApi from '@repo/ui/hooks/api/useApi';
import { STATUS_CODES } from '@repo/utils/constants/statusCodes';

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
