import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from '../store/app.state';
import { getShop } from '../store/dashboard/dashboard.actions';
import { Observable } from 'rxjs';
import { Shop } from '../models/shop.model';
import { distinctUntilChanged } from 'rxjs/operators';

@Component({
	selector: 'app-dashboard',
	templateUrl: './dashboard.component.html',
	styleUrls: ['./dashboard.component.less']
})
export class DashboardComponent implements OnInit {

	form: FormGroup;
	shop$: Observable<Shop> = this.store.select(state => state.dashboard.shop)
		.pipe(distinctUntilChanged());

	constructor(
		private store: Store<AppState>,
	) { }

	ngOnInit(): void {
		this.store.dispatch(getShop());
	}
}
