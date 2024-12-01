import { Component } from '@angular/core';

declare var bootstrap: any; 

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {
  signIn(role: string) {
    console.log(`Signing in as: ${role}`);
    alert(`You selected: ${role}`);
    const modalElement = document.getElementById('signInModal');
    if (modalElement) {
      const modal = bootstrap.Modal.getInstance(modalElement);
      modal?.hide();
    }
  }
}
