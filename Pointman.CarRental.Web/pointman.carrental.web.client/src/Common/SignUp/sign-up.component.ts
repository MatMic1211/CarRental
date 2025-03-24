import { Component, EventEmitter, Output } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  @Output() closeModal = new EventEmitter<void>();
  @Output() switchToLogin = new EventEmitter<void>();

  email = '';
  password = '';
  confirmPassword = '';
  isLoginMode = false; 

  constructor(private translateService: TranslateService) { }

  closeSignUpModal() {
    this.closeModal.emit();
  }

  goToLogin() {
    this.isLoginMode = true;
  }

  registerUser() {
    if (this.password !== this.confirmPassword) {
      alert('Hasła nie są takie same!');
      return;
    }
    console.log('Rejestracja użytkownika:', this.email);
    this.closeSignUpModal();
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }
}
