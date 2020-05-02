import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchedulesComponent } from './schedules/schedules.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
	{ path: '', component: SchedulesComponent }
];

@NgModule({
	declarations: [SchedulesComponent],
	imports: [
		CommonModule,
		RouterModule.forChild(routes)
	]
})
export class TurnsSchedulerModule { }
