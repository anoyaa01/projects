import { Component, NgModule } from '@angular/core';
import { ProfileService } from '../profile.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms';

export interface UserProfile {
  name: string;
  phoneNumber: string;
  amount: number;
}

@Component({
  selector: 'app-view-profile',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './view-profile.component.html',
  styleUrl: './view-profile.component.scss'
})
export class ViewProfileComponent {

  id: number = 1;
  amount:number=0;
  userData: UserProfile | null = null;
  update: boolean=false;

  constructor(private profile: ProfileService) { }

  ngOnInit(): void {
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
    //console.log("amt n  onconfirm",this.amount)
    //console.log("id n  onconfirm",this.id)

    this.profile.updateBudgetService(this.id,this.amount).subscribe({
      next: (data) => {
        console.log('Fetched expenses budget update:', data);
        console.log(this.amount);
        this.amount= data;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }
}