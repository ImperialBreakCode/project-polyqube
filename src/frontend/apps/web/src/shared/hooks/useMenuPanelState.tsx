import { useAppSelector } from '@/redux';
import { selectMenuPanel } from '@/shared/actions';

const useMenuPanelState = () => useAppSelector(selectMenuPanel);

export default useMenuPanelState;
