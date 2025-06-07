import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  contactForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private http: HttpClient, private translateService: TranslateService,) {
    this.contactForm = this.fb.group({
      fromEmail: ['', [Validators.required, Validators.email]],
      subject: ['', Validators.required],
      message: ['', Validators.required],

    });
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  onSubmit() {
    if (this.contactForm.valid) {
      this.http.post('https://localhost:7001/api/contact', this.contactForm.value).subscribe({
        next: () => {
          this.successMessage = 'Wiadomość została wysłana!';
          this.contactForm.reset();
        },
        error: () => {
          this.errorMessage = 'Błąd przy wysyłaniu wiadomości.';
        }
      });
    }
  }
}
