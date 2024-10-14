import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from '../MainPage/main-page.component';
import { AdminMenuComponent } from '../Administrator/AdministratorMenu/admin-menu.component';
import { HomeComponent } from '../Common/HomePage/home.component';
import { CompaniesListComponent } from '../Common/CompaniesList/companies-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    AdminMenuComponent,
    HomeComponent,
    CompaniesListComponent

  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
