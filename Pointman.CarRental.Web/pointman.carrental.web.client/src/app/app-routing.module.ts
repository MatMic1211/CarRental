import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from '../MainPage/main-page.component';
import { CompaniesListComponent } from '../Common/CompaniesList/companies-list.component';
import { CarListComponent } from '../Company/Car/CarList/car-list.component';
import { CompanyRentalsComponent } from '../Company/CompanyRental/company-rentals.component';
import { ContactComponent } from '../Common/Contact/contact.component';


const routes: Routes = [
  { path: '', component: MainPageComponent },
  { path: 'home', component: MainPageComponent },
  { path: 'cars', component: CarListComponent },
  { path: 'companies', component: CompaniesListComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'company/cars', component: CarListComponent },
  { path: 'company/rentals', component: CompanyRentalsComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
