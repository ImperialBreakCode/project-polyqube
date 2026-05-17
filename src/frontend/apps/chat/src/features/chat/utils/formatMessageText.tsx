import { Fragment, type ReactNode } from 'react';

const INLINE_TOKEN_PATTERN = /\*\*([\s\S]+?)\*\*|\*([\s\S]+?)\*/g;

export function formatMessageText(text: string): ReactNode[] {
	const nodes: ReactNode[] = [];
	let lastIndex = 0;
	let key = 0;
	const pattern = new RegExp(INLINE_TOKEN_PATTERN);

	let match: RegExpExecArray | null = pattern.exec(text);
	while (match !== null) {
		const [full, boldContent, italicContent] = match;

		if (match.index > lastIndex) {
			nodes.push(
				<Fragment key={`t-${key++}`}>
					{text.slice(lastIndex, match.index)}
				</Fragment>,
			);
		}

		if (boldContent !== undefined) {
			nodes.push(
				<strong key={`b-${key++}`} className='font-semibold'>
					{formatMessageText(boldContent)}
				</strong>,
			);
		} else if (italicContent !== undefined) {
			nodes.push(
				<em key={`i-${key++}`} className='italic'>
					{formatMessageText(italicContent)}
				</em>,
			);
		}

		lastIndex = match.index + full.length;
		match = pattern.exec(text);
	}

	if (lastIndex < text.length) {
		nodes.push(
			<Fragment key={`t-${key++}`}>{text.slice(lastIndex)}</Fragment>,
		);
	}

	return nodes;
}
