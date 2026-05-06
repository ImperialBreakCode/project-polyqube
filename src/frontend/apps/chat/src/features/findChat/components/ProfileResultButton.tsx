import {
	Avatar,
	AvatarFallback,
	AvatarImage,
} from '@repo/ui/components/ui/Avatar';
import { Button } from '@repo/ui/components/ui/Button';

interface ProfileResultButtonProps {
	avatarSrc: string;
	avatarFallback: string;
	name: string;
	onClick: () => void;
	disabled?: boolean;
}

const ProfileResultButton = ({
	avatarSrc,
	avatarFallback,
	name,
	onClick,
	disabled = false,
}: ProfileResultButtonProps) => {
	return (
		<Button
			variant={'outline'}
			className='w-full justify-start py-[30px!important] cursor-pointer'
			onClick={onClick}
			disabled={disabled}
		>
			<Avatar className='h-8 w-8 rounded-full'>
				<AvatarImage src={avatarSrc} alt={name} />
				<AvatarFallback className='rounded-full uppercase'>
					{avatarFallback}
				</AvatarFallback>
			</Avatar>{' '}
			{name}
		</Button>
	);
};

export default ProfileResultButton;
