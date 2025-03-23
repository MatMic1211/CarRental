import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckPermissionService {
  private apiUrl = 'https://localhost:7001/api/Auth';

  constructor(private http: HttpClient) { }

  checkPermission(permissionCode: string): Observable<boolean>
  {
    return this.http.get<boolean>(`${this.apiUrl}/has-permission?permissionCode=${permissionCode}`);
  }
}

