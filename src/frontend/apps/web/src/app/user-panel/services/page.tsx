import { ServicesList } from '@/features/services';

function ServicesPage() {
	return (
		<div>
			<h2 className='text-3xl p-5'>PolyQube Services</h2>
			<div className='px-2'>
				<ServicesList />
			</div>
		</div>
	);
}

export default ServicesPage;
