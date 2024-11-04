import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  constructor(private http: HttpClient) { }

  getCategoryList(userId:number) : Observable<any>{
    //console.log(userId)
    const params = new HttpParams().set('id', userId);
    return this.http.get<string[]>(`http://localhost:5277/api/Category`, { params });
  }
}
