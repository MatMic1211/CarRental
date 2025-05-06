import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export interface Company {
  id: number;
  name: string;
  location: string;
  telephoneNumber: string;
}

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private apiUrl = 'https://localhost:7001/api/Companies';

  constructor(private httpClientService: HttpClientService) { }

  getCompanies(): Observable<Company[]> {
    return this.httpClientService.get<Company[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  addCompany(company: Company): Observable<Company> {
    return this.httpClientService.post<Company>(this.apiUrl, company)
      .pipe(catchError(this.handleError));
  }

  updateCompany(id: number, companyData: Company): Observable<Company> {
    const url = `${this.apiUrl}/${id}`;
    return this.httpClientService.put<Company>(url, companyData)
      .pipe(catchError(this.handleError));
  }

  deleteCompany(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.httpClientService.delete<void>(url)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: any): Observable<never> {
    console.error('Error occurred:', error);
    return throwError(() => new Error('Something went wrong. Please try again later.'));
  }
}
