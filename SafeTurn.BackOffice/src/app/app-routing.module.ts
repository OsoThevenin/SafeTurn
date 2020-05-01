import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ROUTE_LOGIN, ROUTE_NOTFOUND } from './shared/constants/app-routes';



const routes: Routes = [
  { path: ROUTE_LOGIN, loadChildren: () => import('./authentication/login/login.module').then(m => m.LoginModule) },
  { path: '',				redirectTo: ROUTE_LOGIN,	pathMatch: 'full' },
	{ path: ROUTE_NOTFOUND,	redirectTo: ROUTE_LOGIN,	pathMatch: 'full' },
	{ path: '**',			redirectTo: ROUTE_LOGIN,	pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
