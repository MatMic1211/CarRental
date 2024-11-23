import { Component, OnInit } from '@angular/core';
import { Company, CompanyService } from '../../../Services/companies.service';

@Component({
  selector: 'app-companies-list',
  templateUrl: './companies-list.component.html',
  styleUrls: ['./companies-list.component.css'],
})
export class CompaniesListComponent implements OnInit {
  companies: Company[] = [];
  paginatedCompanies: Company[] = [];
  currentPage = 1;
  itemsPerPage = 10;
  totalPages = 1;
  isFormOpen = false;
  isEditing = false;
  isDeleteConfirmationOpen = false;
  editingCompany: Company | null = null;
  companyToDelete: Company | null = null;

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.refreshCompanies();
  }

  refreshCompanies(): void {
    this.companyService.getCompanies().subscribe({
      next: (data) => {
        this.companies = data;
        this.calculatePagination();
      },
      error: (err) => {
        console.error('Error fetching companies', err);
      },
    });
  }

  calculatePagination(): void {
    this.totalPages = Math.ceil(this.companies.length / this.itemsPerPage);
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedCompanies = this.companies.slice(startIndex, endIndex);
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.calculatePagination();
    }
  }

  openForm(): void {
    this.isFormOpen = true;
    this.isEditing = false;
    this.editingCompany = null;
  }

  closeForm(): void {
    this.isFormOpen = false;
    this.isEditing = false;
    this.editingCompany = null;
  }

  addCompanyToList(company: Company): void {
    this.refreshCompanies();
    this.closeForm();
  }

  editCompany(company: Company): void {
    this.isEditing = true;
    this.editingCompany = { ...company };
    this.isFormOpen = true;
  }

  openDeleteConfirmation(company: Company): void {
    this.isDeleteConfirmationOpen = true;
    this.companyToDelete = company;
  }

  closeDeleteConfirmation(): void {
    this.isDeleteConfirmationOpen = false;
    this.companyToDelete = null;
  }

  confirmDeleteCompany(): void {
    if (this.companyToDelete) {
      this.companyService.deleteCompany(this.companyToDelete.id).subscribe({
        next: () => {
          this.refreshCompanies();
          this.closeDeleteConfirmation();
        },
        error: (err) => {
          console.error('Error deleting company:', err);
          this.closeDeleteConfirmation();
        },
      });
    }
  }
}
