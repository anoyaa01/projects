import { Component } from '@angular/core';
import { ProfileService } from '../profile.service';

export interface UserProfile {
  name: string;
  phoneNumber: string;
  amount: number;
}

@Component({
  selector: 'app-view-profile',
  standalone: true,
  imports: [],
  templateUrl: './view-profile.component.html',
  styleUrl: './view-profile.component.scss'
})
export class ViewProfileComponent {
  id: number = 1;
  userData: UserProfile | null = null;

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
    this.profile.updateBudget(this.id).subscribe({
      next: (data) => {
        console.log('Fetched expenses:', data);
        this.userData = data;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }
}