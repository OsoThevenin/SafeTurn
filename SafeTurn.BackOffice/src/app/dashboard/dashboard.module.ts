import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { dashboardReducer } from '../store/dashboard/dashboard.reducer';
import { DashboardEffects } from '../store/dashboard/dashboard.effects';
import { ShopFormComponent } from './shop-form/shop-form.component';
import { ShopScheduleComponent } from './shop-schedule/shop-schedule.component';

const routes: Routes = [
	{
		path: '',
		component: DashboardComponent,
	}
]

@NgModule({
	declarations: [DashboardComponent, ShopFormComponent, ShopScheduleComponent],
	imports: [
		RouterModule.forChild(routes),
		StoreModule.forFeature('dashboard', dashboardReducer),
		EffectsModule.forFeature([DashboardEffects]),
		SharedModule,
	]
})
export class DashboardModule { }
