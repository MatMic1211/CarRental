import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClientService } from './http-client.service';

export interface Car {
  id: number;
  brand: string;
  model: string;
}

export interface PagedResult<T> {
  items: T[];
  totalCount: number;
}

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private apiUrl = 'https://localhost:7001/api/Cars';

  constructor(private httpClientService: HttpClientService) { }

  getCarsPaged(page: number, size: number, brand?: string, model?: string): Observable<PagedResult<Car>> {
    let url = `${this.apiUrl}?pageNumber=${page}&pageSize=${size}`;

    if (brand) url += `&brand=${encodeURIComponent(brand)}`;
    if (model) url += `&model=${encodeURIComponent(model)}`;

    return this.httpClientService.get<PagedResult<Car>>(url)
      .pipe(catchError(this.handleError));
  }
  getCars(): Observable<Car[]> {
    return this.httpClientService.get<Car[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  addCar(car: Partial<Car>): Observable<Car> {
    return this.httpClientService.post<Car>(this.apiUrl, car)
      .pipe(catchError(this.handleError));
  }

  updateCar(id: number, car: Partial<Car>): Observable<Car> {
    const url = `${this.apiUrl}/${id}`;
    return this.httpClientService.put<Car>(url, car)
      .pipe(catchError(this.handleError));
  }

  deleteCar(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.httpClientService.delete<void>(url)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: any): Observable<never> {
    console.error('CarService error:', error);
    return throwError(() => new Error('Something went wrong. Please try again later.'));
  }
}
