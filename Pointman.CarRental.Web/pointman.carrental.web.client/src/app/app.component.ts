import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Company, CompanyService } from '../../Services/companies.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  showCompanyMenu = false;
  companies: Company[] = [];
  selectedCompanyName: string = 'Logo';

  constructor(
    private companyService: CompanyService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadCompanies();
  }

  switchToCompanyMenu() {
    this.showCompanyMenu = true;
    this.router.navigate(['/home']); 
  }

  switchToAdminMenu() {
    this.showCompanyMenu = false;
    this.router.navigate(['/home']); 
  }

  loadCompanies(): void {
    this.companyService.getCompanies().subscribe(
      (data) => {
        this.companies = data;
        console.log('Loaded companies:', this.companies);
      },
      (error) => {
        console.error('Error fetching companies:', error);
      }
    );
  }

  updateCompanyName(selectedCompany: string) {
    console.log('Selected company in AppComponent:', selectedCompany);
    this.selectedCompanyName = selectedCompany;
    this.cdr.detectChanges();
  }


}
