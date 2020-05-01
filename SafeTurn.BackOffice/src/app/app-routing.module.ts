import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ROUTE_LOGIN, ROUTE_NOTFOUND, ROUTE_DASHBOARD, ROUTE_TURNS_SCHEDULER } from './shared/constants/app-routes';
import { AppLayoutComponent } from './shared/app-layout/app-layout.component';

const routes: Routes = [
	{
		path: '',
		component: AppLayoutComponent,
		children: [
			{
				path: ROUTE_DASHBOARD,
			  	loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
			},
			{
				path: ROUTE_TURNS_SCHEDULER,
			  	loadChildren: () => import('./turns-scheduler/turns-scheduler.module').then(m => m.TurnsSchedulerModule)
			},
		]
	},
	{ path: '', redirectTo: ROUTE_DASHBOARD, pathMatch: 'full' },
	{ path: ROUTE_LOGIN, loadChildren: () => import('./authentication/login/login.module').then(m => m.LoginModule) },
	{ path: ROUTE_NOTFOUND, redirectTo: ROUTE_LOGIN, pathMatch: 'full' },
	{ path: '**', redirectTo: ROUTE_LOGIN, pathMatch: 'full' },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
