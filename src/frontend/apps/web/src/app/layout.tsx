import type { Metadata } from 'next';
import { ThemeProvider } from 'next-themes';
import localFont from 'next/font/local';
import { Toaster } from '@repo/ui/components/ui/Sonner';
import '@/app/globals.css';
import ReduxProvider from '@/redux/ReduxProvider';

const urbanist = localFont({
	src: '../fonts/Urbanist/Urbanist-VariableFont_wght.ttf',
	variable: '--font-urbanist',
	style: 'normal',
	display: 'swap',
});

const urbanistItalic = localFont({
	src: '../fonts/Urbanist/Urbanist-Italic-VariableFont_wght.ttf',
	variable: '--font-urbanist-italic',
	style: 'italic',
	display: 'swap',
});

const merriweather = localFont({
	src: '../fonts/Merriweather/Merriweather-VariableFont_opsz,wdth,wght.ttf',
	variable: '--font-merriweather',
	style: 'normal',
	display: 'swap',
});

const merriweatherItalic = localFont({
	src: '../fonts/Merriweather/Merriweather-Italic-VariableFont_opsz,wdth,wght.ttf',
	variable: '--font-merriweather-italic',
	style: 'italic',
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
		<html lang='en' suppressHydrationWarning>
			<body
				className={`${urbanist.variable} ${merriweather.variable}
					${urbanistItalic.variable} ${merriweatherItalic.variable}
					font-urbanist antialiased`}
			>
				<ThemeProvider
					attribute='class'
					defaultTheme='system'
					enableSystem
					disableTransitionOnChange
				>
					<ReduxProvider>{children}</ReduxProvider>
				</ThemeProvider>
				<Toaster />
			</body>
		</html>
	);
}
