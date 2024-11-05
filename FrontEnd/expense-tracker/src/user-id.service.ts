import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerServiceService } from './customer-service.service';


@Injectable({
  providedIn: 'root'
})
export class UserIdService {

  userId: number| null = null;
  constructor(private customerService: CustomerServiceService) { }

  setUserId(id: number): void {
    this.userId = id;
    console.log("SETuserid calledd")
  }

  getUserId(): number{
    console.log("GETuserid calledd")
    return this.userId!;
  }
}
