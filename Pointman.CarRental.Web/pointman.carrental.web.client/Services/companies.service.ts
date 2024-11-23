import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
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

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.apiUrl).pipe(catchError(this.handleError));
  }

  addCompany(company: Company): Observable<Company> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.post<Company>(this.apiUrl, company, { headers }).pipe(catchError(this.handleError));
  }

  updateCompany(id: number, companyData: Company): Observable<Company> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<Company>(url, companyData, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    }).pipe(catchError(this.handleError));
  }

  deleteCompany(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    console.error('Error occurred:', error.message);
    return throwError(() => new Error('Something went wrong. Please try again later.'));
  }
}
