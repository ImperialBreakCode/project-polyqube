import PanelNavLink from './PanelNavLink';
import PanelNavLinkSmall from './PanelNavLinkSmall';
import CloseNavPanelButton from './CloseNavPanelButton';

const NavPanel = () => {
	return (
		<div
			className='fixed top-0 left-0 w-full bg-[#181818] h-screen z-100
				text-white'
		>
			<div
				className='my-30 mx-20 flex flex-row justify-between
					items-center'
			>
				<p className='text-5xl font-merriweather'>PolyQube</p>

				<div className='space-x-5 flex'>
					<PanelNavLinkSmall href={'#'}>Login</PanelNavLinkSmall>
					<PanelNavLinkSmall href={'#'}>Register</PanelNavLinkSmall>
					<CloseNavPanelButton />
				</div>
			</div>
			<div className='flex flex-col text-4xl p-10'>
				<PanelNavLink className='border-t' href={'#'}>
					<span className='text-xl text-gray-300'>/01 - </span>
					Home
				</PanelNavLink>
				<PanelNavLink href={'#'}>
					<span className='text-xl text-gray-300'>/02 - </span>
					About
				</PanelNavLink>
				<PanelNavLink href={'#'}>
					<span className='text-xl text-gray-300'>/03 - </span>
					Services
				</PanelNavLink>
			</div>
		</div>
	);
};

export default NavPanel;
