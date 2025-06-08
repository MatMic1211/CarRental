import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from '../../../Services/contact.service';
import { TranslateService } from '../../../Services/translate.service';

// Lokalny interfejs ContactRequest
interface ContactRequest {
  fromEmail: string;
  subject: string;
  message: string;
}

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  contactForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private translateService: TranslateService
  ) {
    this.contactForm = this.fb.group({
      fromEmail: ['', [Validators.required, Validators.email]],
      subject: ['', Validators.required],
      message: ['', Validators.required]
    });
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  onSubmit() {
    if (this.contactForm.valid) {
      const request: ContactRequest = this.contactForm.value;

      this.contactService.sendContactRequest(request).subscribe({
        next: () => {
          this.successMessage = 'Wiadomość została wysłana!';
          this.errorMessage = '';
          this.contactForm.reset();
        },
        error: () => {
          this.successMessage = '';
          this.errorMessage = 'Błąd przy wysyłaniu wiadomości.';
        }
      });
    }
  }
}
