import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Company {
  id: number;
  name: string;
  location: string;
  telephoneNumber: string; 
}

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = 'https://localhost:7001/api/Companies';

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.apiUrl);
  }
}
