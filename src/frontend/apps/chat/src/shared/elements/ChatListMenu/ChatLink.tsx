import Link from 'next/link';

interface ChatLinkProps {
	name: string;
	href: string;
	isActive?: boolean;
}

const ChatLink = ({ name, href, isActive = false }: ChatLinkProps) => {
	return (
		<Link
			href={href}
			className={`flex items-center gap-x-2 px-4 py-2 rounded-md transition-colors ${
				isActive
					? 'bg-[#4a3f52] text-white'
					: 'text-[#d2d2d2] hover:bg-[#333] hover:text-white'
			}`}
		>
			{name}
		</Link>
	);
};

export default ChatLink;
