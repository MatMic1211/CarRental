import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from '../MainPage/main-page.component';
import { AdminMenuComponent } from '../Administrator/AdministratorMenu/admin-menu.component';
import { CompaniesListComponent } from '../Common/CompaniesList/companies-list.component';
import { CompaniesFormComponent } from '../Common/CompaniesList/CompaniesForm/companies-form.component';
import { CompanyMenuComponent } from '../Company/CompanyMenu/company-menu.component';
import { CarListComponent } from '../Company/Car/CarList/car-list.component';
import { CompanyRentalsComponent } from '../Company/CompanyRental/company-rentals.component';
import { LoginUserComponent } from '../Common/SignIn/UserLogin/user-login.component';
import { SignUpComponent } from '../Common/SignUp/sign-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthInterceptor } from './Interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    AdminMenuComponent,
    CompaniesListComponent,
    CompaniesFormComponent,
    CompanyMenuComponent,
    CarListComponent,
    CompanyRentalsComponent,
    LoginUserComponent,
    SignUpComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
