import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface User {
  userName: string;
  role: string; 
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:7001/api/auth';

  constructor(private http: HttpClient) { }

  login(email: string): Observable<{ userName: string }> {
    return this.http.post<{ userName: string }>(`${this.apiUrl}/login`, { email });
  }
}
