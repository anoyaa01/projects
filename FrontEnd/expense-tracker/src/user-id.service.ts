import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerServiceService } from './customer-service.service';


@Injectable({
  providedIn: 'root'
})
export class UserIdService {

  userId: number= 0;
  constructor(private customerService: CustomerServiceService) { }

  setUserId(id: number): void {
    this.userId = id;
    console.log("SETuserid calledd")
  }

}
