import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Company } from '../../../Services/companies.service';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-company-menu',
  templateUrl: './company-menu.component.html',
  styleUrls: ['./company-menu.component.css'],
})
export class CompanyMenuComponent {
  @Input() companies: Company[] = [];
  @Input() selectedCompanyName: string = 'Logo';
  @Output() switchToAdmin = new EventEmitter<void>();
  @Output() companySelected = new EventEmitter<string>();

  showModal = false;
  selectedCompanyId: number | null = null;
  isDropdownOpen = false;
  isMenuCollapsed = true;
  currentLanguage: string = 'en';  

  constructor(public translateService: TranslateService) { }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  openSignInModal() {
    this.showModal = true;
  }

  closeSignInModal(option: string) {
    if (option === 'Admin') {
      this.switchToAdmin.emit();
    } else if (option === 'Company' && this.selectedCompanyId !== null) {
      const selectedCompany = this.companies.find(
        (company) => company.id === this.selectedCompanyId
      );
      if (selectedCompany) {
        console.log('Company selected in CompanyMenuComponent:', selectedCompany.name);
        this.companySelected.emit(selectedCompany.name);
      }
    }
    this.showModal = false;
  }

  changeLanguage(lang: string) {
    this.translateService.setLanguage(lang);
    this.currentLanguage = lang;
    this.isDropdownOpen = false;  
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  closeDropdown() {
    this.isDropdownOpen = false;
  }

  toggleMenu() {
    this.isMenuCollapsed = !this.isMenuCollapsed;
  }
}
