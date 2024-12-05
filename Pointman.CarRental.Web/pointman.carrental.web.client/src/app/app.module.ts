import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from '../MainPage/main-page.component';
import { AdminMenuComponent } from '../Administrator/AdministratorMenu/admin-menu.component';
import { HomeComponent } from '../Common/HomePage/home.component';
import { CompaniesListComponent } from '../Common/CompaniesList/companies-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompaniesFormComponent } from '../Common/CompaniesList/CompaniesForm/companies-form.component';
import { CompanyMenuComponent } from '../Company/CompanyMenu/company-menu.component';
import { CarListComponent } from '../Company/Car/CarList/car-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    AdminMenuComponent,
    HomeComponent,
    CompaniesListComponent,
    CompaniesFormComponent,
    CompanyMenuComponent,
    CarListComponent
    

  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, ReactiveFormsModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
