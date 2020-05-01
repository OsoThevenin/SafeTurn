import { createReducer, on, Action } from '@ngrx/store';
import { Shop } from 'src/app/models/shop.model';
import { setLoading, getShopSuccess, getShop } from './dashboard.actions';

export interface DashboardState {
	loading: boolean;
	shop: Shop
}

export const initialState: DashboardState = {
	loading: false,
	shop: null
}

const _reducer = createReducer(initialState,
	on(setLoading, (state, { loading }) => ({ ...state, loading })),
	on(getShop, (state) => ({ ...state, loading: true })),
	on(getShopSuccess, (state, { shop }) => ({ ...state, loading: false, shop }))
);

export function dashboardReducer(state: DashboardState, action) {
	return _reducer(state, action);
}