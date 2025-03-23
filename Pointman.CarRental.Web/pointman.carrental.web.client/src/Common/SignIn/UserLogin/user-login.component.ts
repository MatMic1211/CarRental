import { Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../../../../Services/auth.service';
import { TranslateService } from '../../../../Services/translate.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class LoginUserComponent {
  loggedInUser: { userName: string } | null = null;
  email: string = '';

  @Output() closeModal = new EventEmitter<void>();
  @Output() userLoggedIn = new EventEmitter<{ userName: string }>();

  constructor(
    private translateService: TranslateService,
    private authService: AuthService
  ) { }

  login(): void {
    if (this.email) {
      this.authService.login(this.email).subscribe(
        (response) => {
          this.loggedInUser = response;
          this.userLoggedIn.emit(this.loggedInUser);
          this.closeModal.emit();
        },
        (error) => {
          alert('Użytkownik nie został znaleziony'); 
        }
      );
    }
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  logout(): void {
    this.loggedInUser = null;
    this.email = '';
  }
}
