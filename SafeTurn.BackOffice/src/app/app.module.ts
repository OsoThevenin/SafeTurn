import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginModule } from './authentication/login/login.module';
import { SharedModule } from './shared/shared.module';
import { environment } from 'src/environments/environment';

@NgModule({
	declarations: [
		AppComponent,
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		SharedModule,
		StoreModule.forRoot({}),
		EffectsModule.forRoot([]),
		StoreDevtoolsModule.instrument({
			maxAge: 25, // Retains last 25 states
			logOnly: environment.production, // Restrict extension to log-only mode
		}),
		LoginModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
