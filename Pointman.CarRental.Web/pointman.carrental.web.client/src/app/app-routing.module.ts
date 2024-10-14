import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from '../MainPage/main-page.component';
import { CompaniesListComponent } from '../Common/CompaniesList/companies-list.component';


const routes: Routes = [
  { path: '', component: MainPageComponent },
  { path: 'home', component: MainPageComponent },
  { path: 'companies', component: CompaniesListComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
