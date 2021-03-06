import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
	declarations: [LoginComponent],
	imports: [
		RouterModule.forChild([
			{ path: '', component: LoginComponent }
		]),
		SharedModule
	]
})
export class LoginModule { }
