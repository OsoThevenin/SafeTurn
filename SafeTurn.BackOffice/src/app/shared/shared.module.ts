import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { RouterModule } from '@angular/router';

@NgModule({
	imports: [
		CommonModule,
		RouterModule,
		ReactiveFormsModule
	],
	declarations: [
		NavbarComponent,
		AppLayoutComponent
	],
	exports: [
		CommonModule,
		ReactiveFormsModule,
		NavbarComponent,
		AppLayoutComponent
	]
})
export class SharedModule { }
