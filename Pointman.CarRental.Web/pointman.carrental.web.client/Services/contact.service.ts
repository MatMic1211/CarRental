import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface ContactRequest {
  fromEmail: string;
  subject: string;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = 'https://localhost:7001/api/contact'; 

  constructor(private http: HttpClient) { }

  sendContactRequest(request: ContactRequest): Observable<void> {
    return this.http.post<void>(this.apiUrl, request);
  }
}
