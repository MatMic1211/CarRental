import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7001/api/auth';

  constructor(private http: HttpClient) { }

  register(email: string, password: string, firstName: string, lastName: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, {
      email,
      password,
      firstName,
      lastName
    });
  }

  login(email: string): Observable<{ userName: string }> {
    return this.http.post<{ userName: string }>(`${this.apiUrl}/login`, { email });
  }
}
