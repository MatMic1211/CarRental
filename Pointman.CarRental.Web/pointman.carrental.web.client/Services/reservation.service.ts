import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Reservation {
  carId: number;
  customerName: string;
  email: string;
  startDate: string;
  endDate: string;
  startTime: string; 
  endTime: string;
  pickupLocation: string;
  returnLocation: string;
}

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private apiUrl = 'https://localhost:7001/api/Reservations';

  constructor(private http: HttpClient) { }

  createReservation(reservation: Reservation): Observable<any> {
    return this.http.post(this.apiUrl, reservation);
  }
}
