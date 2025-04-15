import { Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../../../../Services/auth.service';
import { TranslateService } from '../../../../Services/translate.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class LoginUserComponent {
  loggedInUser: { token: string } | null = null;
  email: string = '';
  password: string = '';

  @Output() closeModal = new EventEmitter<void>();
  @Output() userLoggedIn = new EventEmitter<{ token: string }>();

  constructor(
    private translateService: TranslateService,
    private authService: AuthService
  ) { }

  login(): void {
    if (this.email && this.password) {
      this.authService.login(this.email, this.password).subscribe(
        (response) => {
          this.loggedInUser = response;
          localStorage.setItem('jwtToken', response.token); 
          this.userLoggedIn.emit(this.loggedInUser);
          this.closeModal.emit();
        },
        (error) => {
          alert(this.getTranslation('LOGIN_ERROR') || 'Użytkownik nie został znaleziony');
        }
      );
    } else {
      alert(this.getTranslation('FILL_EMAIL_PASSWORD') || 'Wprowadź e-mail i hasło.');
    }
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  logout(): void {
    this.loggedInUser = null;
    this.email = '';
    this.password = '';
    localStorage.removeItem('jwtToken');
  }
}
