
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7001/api/auth';

  constructor(private http: HttpClient) { }

  register(email: string, password: string, firstName: string, lastName: string, roleName: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, {
      email,
      password,
      firstName,
      lastName,
      roleName
    });
  }


  login(email: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { email, password }).pipe(
      tap(response => {
        localStorage.setItem('jwtToken', response.token); 
      })
    );
  }

  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = token.split('.')[1];
    const decodedPayload = atob(payload);
    const parsedPayload = JSON.parse(decodedPayload);

    return (
      parsedPayload['role'] ||
      parsedPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ||
      null
    );
  }


  logout(): void {
    localStorage.removeItem('jwtToken');
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  isAdmin(): boolean {
    return this.getUserRole() === 'Admin';
  }

  isUser(): boolean {
    return this.getUserRole() === 'User';
  }
}
