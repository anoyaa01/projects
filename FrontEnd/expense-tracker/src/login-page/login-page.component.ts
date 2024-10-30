import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet, Routes } from '@angular/router';
import { SignupPageComponent } from '../signup-page/signup-page.component';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [RouterOutlet, RouterLinkActive,RouterLink,RouterModule,SignupPageComponent],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})

export class LoginPageComponent {

  LoginMethod()
  {
    //method to do when login click values happen to be a success  i.e. to the track expense/ home page
  }
}
