import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import { AppComponent } from './app.component';

//views
import { HomeComponent } from './views/home/home.component';
import { NotFoundComponent } from './views/not-found/not-found.component';

//components
import { HomeCardComponent } from './components/home-card/home-card.component';
import { HeaderComponent } from './components/header/header.component';

//routes
const appRoutes: Routes =[
  { path: '', component: HomeComponent},
  { path: 'home', component: HomeComponent},
  { path: 'employees', redirectTo: '/notFound'},
  { path: 'companies', redirectTo: '/notFound'},
  { path: 'positions', redirectTo: '/notFound'},
  { path: 'activityTypes', redirectTo: '/notFound'},
  { path: 'legalForms', redirectTo: '/notFound'},
  { path: 'notFound', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    HomeCardComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
