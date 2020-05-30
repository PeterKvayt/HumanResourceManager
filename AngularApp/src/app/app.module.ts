import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

// views
import { HomeComponent } from './views/home/home.component';
import { NotFoundComponent } from './views/not-found/not-found.component';
import { ApiComponent } from './views/api/api.component';
import { ActivityTypesComponent } from './views/activity-types/activity-types.component';

// components
import { HomeCardComponent } from './components/home-card/home-card.component';
import { HeaderComponent } from './components/header/header.component';
import { ApiCardComponent } from './components/api-card/api-card.component';
import { FooterComponent } from './components/footer/footer.component';
import { CreateActivityTypeComponent } from './views/activity-types/create/create-activity-type.component';

// routes
const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'Home', component: HomeComponent},
  { path: 'Api', component: ApiComponent},
  // { path: 'employees', redirectTo: '/notFound'},
  // { path: 'companies', redirectTo: '/notFound'},
  // { path: 'positions', redirectTo: '/notFound'},
  // { path: 'legalForms', redirectTo: '/notFound'},
  { path: 'ActivityTypes', component: ActivityTypesComponent},
  { path: 'ActivityTypes/Create', component: CreateActivityTypeComponent, pathMatch: 'full'},
  { path: 'NotFound', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    HomeCardComponent,
    HeaderComponent,
    ApiComponent,
    ApiCardComponent,
    FooterComponent,
    ActivityTypesComponent,
    CreateActivityTypeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [Title],
  bootstrap: [AppComponent]
})
export class AppModule { }
