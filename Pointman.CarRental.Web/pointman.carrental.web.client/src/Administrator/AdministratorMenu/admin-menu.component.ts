import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';
import { Company, CompanyService } from '../../../Services/companies.service';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.css'],
})
export class AdminMenuComponent implements OnInit {
  showModal = false;
  isDropdownOpen = false;
  isMenuOpen = false; 
  companies: Company[] = [];
  selectedCompany: number | null = null;
  currentLanguage: string = 'en';  

  @Output() switchToCompany = new EventEmitter<void>();

  constructor(
    private translateService: TranslateService,
    private companyService: CompanyService
  ) { }

  ngOnInit(): void {
    this.loadCompanies();
    this.isDropdownOpen = false; 
  }

  loadCompanies(): void {
    this.companyService.getCompanies().subscribe(
      (data) => {
        this.companies = data;
      },
      (error) => {
        console.error('Error fetching companies:', error);
      }
    );
  }

  addCompany(newCompany: Company): void {
    this.companyService.addCompany(newCompany).subscribe(
      (createdCompany) => {
        console.log('Company added:', createdCompany);
        this.loadCompanies();
      },
      (error) => {
        console.error('Error adding company:', error);
      }
    );
  }

  openSignInModal() {
    this.showModal = true;
  }

  closeSignInModal(option: string) {
    this.showModal = false;
    if (option === 'Company') {
      this.switchToCompany.emit();
    }
    console.log('Selected company ID:', this.selectedCompany);
  }

  changeLanguage(lang: string) {
    this.translateService.setLanguage(lang);
    this.currentLanguage = lang; 
    this.isDropdownOpen = false;  
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  closeDropdown() {
    this.isDropdownOpen = false;
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
