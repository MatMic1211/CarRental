import { Component, OnInit } from '@angular/core';
import { Company, CompanyService } from '../../../Services/companies.service';

@Component({
  selector: 'app-companies-list',
  templateUrl: './companies-list.component.html',
  styleUrls: ['./companies-list.component.css']
})
export class CompaniesListComponent implements OnInit {
  companies: Company[] = [];

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.companyService.getCompanies().subscribe({
      next: (data) => {
        this.companies = data;
      },
      error: (err) => {
        console.error('Błąd podczas pobierania danych', err);
      }
    });
  }
}
