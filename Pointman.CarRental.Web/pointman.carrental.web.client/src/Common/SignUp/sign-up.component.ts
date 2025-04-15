import { Component, EventEmitter, Output } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';
import { AuthService } from '../../../Services/auth.service';

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
  firstName = '';
  lastName = '';
  isLoginMode = false;

  constructor(private translateService: TranslateService, private authService: AuthService) { }

  closeSignUpModal() {
    this.closeModal.emit();
  }

  goToLogin() {
    this.isLoginMode = !this.isLoginMode;
  }

  registerUser() {
    if (this.password !== this.confirmPassword) {
      alert('Hasła nie są takie same!');
      return;
    }

    this.authService.register(this.email, this.password, this.firstName, this.lastName).subscribe(
      response => {
        alert('Rejestracja zakończona pomyślnie!');
        this.closeSignUpModal();
      },
      error => {
        alert('Wystąpił błąd podczas rejestracji.');
      }
    );
  }

  loginUser() {
    this.authService.login(this.email, this.password).subscribe(
      response => {
        alert('Zalogowano pomyślnie!');
        this.closeSignUpModal();
      },
      error => {
        alert('Błąd logowania. Sprawdź email i hasło.');
      }
    );
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }
}
