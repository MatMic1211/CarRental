import { Component, EventEmitter, Output } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.css'],
})
export class AdminMenuComponent {
  showModal = false;
  isDropdownOpen = false;

  @Output() switchToCompany = new EventEmitter<void>();

  constructor(private translateService: TranslateService) { }

  openSignInModal() {
    this.showModal = true;
  }

  closeSignInModal(option: string) {
    this.showModal = false;
    if (option === 'Company') {
      this.switchToCompany.emit();
    }
  }

  changeLanguage(lang: string) {
    this.translateService.setLanguage(lang);
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
}
