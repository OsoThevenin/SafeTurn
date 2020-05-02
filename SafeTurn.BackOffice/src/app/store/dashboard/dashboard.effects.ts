import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';
import { ShopService } from '../../services/shop.service';
import { getShopSuccess, getShop } from './dashboard.actions';
import { Shop } from 'src/app/models/shop.model';

@Injectable()
export class DashboardEffects {
	constructor(
		private actions$: Actions,
		private _shopService: ShopService
	) { }

	loadShop$ = createEffect(() => this.actions$.pipe(
		ofType(getShop),
		mergeMap(() => this._shopService.get()
			.pipe(
				map(shop => {
					if (!shop) shop = Shop.create();
					return getShopSuccess({ shop });
				}),
				catchError(() => EMPTY)
			))
		)
	);
}