import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from '@angular/router';
import { LoginPageComponent } from "../login-page/login-page.component";
import { CategoryExpenseComponent } from "../category-expense/category-expense.component";
import { SignupPageComponent } from "../signup-page/signup-page.component";
import { TrackExpenseComponent } from "../track-expense/track-expense.component";
import { ViewProfileComponent } from "../view-profile/view-profile.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginPageComponent, CategoryExpenseComponent, SignupPageComponent, TrackExpenseComponent, ViewProfileComponent,RouterLinkActive,RouterLink,RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'expense-tracker';
}
