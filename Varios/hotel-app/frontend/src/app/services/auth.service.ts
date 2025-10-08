import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(private http: HttpClient) {}

  login(username: string, password: string) {
    return this.http.post<{token: string}>(`${environment.apiBase}/auth/login`, {username, password});
  }

  saveToken(token: string) { localStorage.setItem('jwt', token); }
  getToken() { return localStorage.getItem('jwt'); }
  logout() { localStorage.removeItem('jwt'); }
}
