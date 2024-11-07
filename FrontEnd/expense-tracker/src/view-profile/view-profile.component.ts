import { Component, NgModule } from '@angular/core';
import { ProfileService } from '../profile.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UserIdService } from '../user-id.service';

export interface UserProfile {
  name: string;
  phoneNumber: string;
  amount: number;
}

@Component({
  selector: 'app-view-profile',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './view-profile.component.html',
  styleUrl: './view-profile.component.scss'
})
export class ViewProfileComponent {

  id: number = 1;
  amount:number=0;
  userData: UserProfile | null = null;
  update: boolean=false;

  constructor(private profile: ProfileService,private UserIdService:UserIdService) { }

  ngOnInit(): void {
    this.id=this.UserIdService.userId;
    this.profile.viewProfile(this.id).subscribe({
      next: (data) => {
        console.log('Fetched expenses:', data);
        this.userData = data;
        console.log(this.userData);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }
  updateBudget() {
    this.update=true;
  }

  onConfirm() {
    this.update=false;
    this.profile.updateBudgetService(this.id,this.amount).subscribe({
      next: (data) => {
        console.log('Fetched expenses budget update:', data);
        console.log(this.amount);
        this.amount= data;
        this.profile.viewProfile(this.id).subscribe({
          next: (data) => {
            console.log('Fetched expenses of viewer:', data);
            this.userData = data;
            console.log(this.userData);
          },
          error: (error) => {
            console.error(error);
          }
      })
      },
      error: (error) => {
        console.error(error);
      }
    })
}
}