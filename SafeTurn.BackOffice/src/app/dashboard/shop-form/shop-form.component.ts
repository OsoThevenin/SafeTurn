import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
	selector: 'app-shop-form',
	templateUrl: './shop-form.component.html',
	styleUrls: ['./shop-form.component.less']
})
export class ShopFormComponent implements OnInit {

	form: FormGroup
	@Input() shop: any;

	constructor(private fb: FormBuilder) { }

	ngOnInit(): void {
		this.form = this.createForm(this.shop);
	}

	submit() {
		console.log(this.form.value);
	}

	private createForm(shop: any) {
		return this.fb.group({
			status: [shop.status],
			name: [shop.name, Validators.required],
			address: [shop.address, Validators.required],
			shopCode: [shop.shopCode, Validators.required],
		});
	}
}
