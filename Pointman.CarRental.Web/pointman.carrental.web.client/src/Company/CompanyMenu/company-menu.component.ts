import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-company-menu',
  templateUrl: './company-menu.component.html',
  styleUrls: ['./company-menu.component.css']
})
export class CompanyMenuComponent {
  showModal = false;

  @Output() switchToAdmin = new EventEmitter<void>();

  openSignInModal() {
    this.showModal = true;
  }

  closeSignInModal(option: string) {
    this.showModal = false;
    console.log(`Option selected: ${option}`);
    if (option === 'Admin') {
      console.log('Navigate to admin login');
      this.switchToAdmin.emit(); 
    } else if (option === 'Company') {
      console.log('Navigate to company login');
    }
  }
}
