import Link from 'next/link';

interface ChatLinkProps {
	name: string;
	href: string;
}

const ChatLink = ({ name, href }: ChatLinkProps) => {
	return (
		<Link
			href={href}
			className='flex items-center gap-x-2 px-4 py-2 hover:bg-[#333]
				rounded-md'
		>
			{name}
		</Link>
	);
};

export default ChatLink;
