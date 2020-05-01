import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { RouterModule } from '@angular/router';



@NgModule({
	imports: [
		CommonModule,
		RouterModule
	],
	declarations: [
		NavbarComponent,
		AppLayoutComponent
	],
	exports: [
		CommonModule,
		FormsModule,
		NavbarComponent,
		AppLayoutComponent
	]
})
export class SharedModule { }
