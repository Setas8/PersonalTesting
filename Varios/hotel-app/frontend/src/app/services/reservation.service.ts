import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ReservationService {
  private base = `${environment.apiBase}/reservations`;
  constructor(private http: HttpClient) {}
  list() { return this.http.get<any[]>(this.base); }
  create(payload: any) { return this.http.post(this.base, payload); }
  cancel(id: number) { return this.http.delete(`${this.base}/${id}`); }
}
