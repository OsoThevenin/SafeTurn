import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

	form: FormGroup;

	constructor(private fb: FormBuilder, private router: Router) { }

	ngOnInit(): void {
		this.form = this.fb.group({
			email: ['', Validators.required],
			password: ['', Validators.required]
		})
	}

	login() {
		this.router.navigate(['/dashboard']);
	}

}
