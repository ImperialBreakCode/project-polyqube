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
		open: (state) => {
			state.open = true;
		},
		close: (state) => {
			state.open = false;
		},
		toggleOpen: (state) => {
			state.open = !state.open;
		},
	},
});

export const { close, open, toggleOpen } = menuPanelSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectCount = (state: RootState) => state.menuPanel.open;

export default menuPanelSlice.reducer;
