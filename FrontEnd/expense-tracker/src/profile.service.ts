import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  viewProfile(id: number): Observable<any> {
    const params = new HttpParams().set('id', id);
    return this.http.get(`http://localhost:5277/api/Users`, { params });
  }

  updateBudget(id: number): Observable<any> {
    const params = new HttpParams().set('id', id);
    return this.http.put(`http://localhost:5277/api/Users`, { params });
  }
}
