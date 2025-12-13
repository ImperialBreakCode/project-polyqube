import type { Metadata } from 'next';
import localFont from 'next/font/local';
import '@/app/globals.css';

const urbanist = localFont({
	src: '../fonts/Urbanist/Urbanist-VariableFont_wght.ttf',
	variable: '--font-urbanist',
	style: 'normal',
	display: 'swap',
});

const merriweather = localFont({
	src: '../fonts/Merriweather/Merriweather-VariableFont_opsz,wdth,wght.ttf',
	variable: '--font-merriweather',
	style: 'normal',
	display: 'swap',
});

export const metadata: Metadata = {
	title: 'PolyQube',
	description: 'One account for everything',
};

export default function RootLayout({
	children,
}: Readonly<{
	children: React.ReactNode;
}>) {
	return (
		<html lang='en'>
			<body
				className={`${urbanist.variable} ${merriweather.variable} font-urbanist antialiased`}
			>
				{children}
			</body>
		</html>
	);
}
