import { createAction, props } from '@ngrx/store';
import { Shop } from '../../models/shop.model';
import { User } from '../../models/user.model';

export const setLoading = createAction('[App] Set loading', props<{ loading: boolean }>());
export const getShop = createAction('[App] Get shop');
export const getShopSuccess = createAction('[App] Get shop success', props<{ shop: Shop}>());
