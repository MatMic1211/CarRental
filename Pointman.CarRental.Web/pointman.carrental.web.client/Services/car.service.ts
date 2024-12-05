import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private apiUrl = 'https://localhost:7001/api/cars'; 

  constructor(private http: HttpClient) { }

  getCars(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addCar(car: { model: string; brand: string }): Observable<any> {
    return this.http.post<any>(this.apiUrl, car);
  }

  deleteCar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  updateCar(id: number, car: { model: string, brand: string }): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, car);
  }
}
