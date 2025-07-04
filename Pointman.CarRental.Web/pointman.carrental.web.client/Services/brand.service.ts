import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface BrandViewModel {
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private apiUrl = 'https://localhost:7001/api/brand';

  constructor(private http: HttpClient) { }

  getBrands(): Observable<BrandViewModel[]> {
    return this.http.get<BrandViewModel[]>(this.apiUrl);
  }
}
