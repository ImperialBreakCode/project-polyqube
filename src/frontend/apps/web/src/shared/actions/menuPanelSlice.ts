import { createSlice } from '@reduxjs/toolkit';
import type { RootState } from '@/redux/store';

export interface MenuPanelState {
	open: boolean;
}

const initialState: MenuPanelState = {
	open: false,
};

export const menuPanelSlice = createSlice({
	name: 'menuPanel',
	initialState,
	reducers: {
		openNavMenu: (state) => {
			state.open = true;
		},
		closeNavMenu: (state) => {
			state.open = false;
		},
		toggleNavMenu: (state) => {
			state.open = !state.open;
		},
	},
});

export const { closeNavMenu, openNavMenu, toggleNavMenu } =
	menuPanelSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectMenuPanel = (state: RootState) => state.menuPanel.open;

export default menuPanelSlice.reducer;
