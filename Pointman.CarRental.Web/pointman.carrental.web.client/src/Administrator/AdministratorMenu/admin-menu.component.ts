import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';
import { Company, CompanyService } from '../../../Services/companies.service';
import { AuthService } from '../../../Services/auth.service';

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
  loggedInUser: { userName: string } | null = null;

  @Output() switchToCompany = new EventEmitter<void>();

  constructor(
    private translateService: TranslateService,
    private companyService: CompanyService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.loadCompanies();
    this.isDropdownOpen = false;

    const email = this.authService.getUserEmail();
    if (email) {
      this.loggedInUser = { userName: email };
    }
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

  openSignUpModal() {
    this.showModal = true;
  }

  closeSignUpModal() {
    this.showModal = false;
  }

  logout() {
    this.authService.logout();
    this.loggedInUser = null;
    window.location.reload();
  }
}
