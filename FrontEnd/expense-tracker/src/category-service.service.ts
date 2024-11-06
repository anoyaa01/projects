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

  getExpenditureByCategory(userId:number) :Observable<any>{
    const params = new HttpParams().set('id', userId);
    return this.http.get<any>(`http://localhost:5277/api/Category/expenditure`, { params });
  }

    addNewCategory(userCategory:any):Observable<any>{
      return this.http.post(`http://localhost:5277/api/Category`,userCategory);
  }

}
