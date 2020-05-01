import { Injectable } from '@angular/core';
import { Shop } from '../models/shop.model';
import { of } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ShopService {

	get() {
		return of({ name: 'mi shop', address: 'calle sants, barcelona', shopCode: '12321aa'} as Shop);
	}

}