import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet, Routes } from '@angular/router';
import { SignupPageComponent } from '../signup-page/signup-page.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IRegister } from '../i-register.interface';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [RouterOutlet, RouterLinkActive, RouterLink, RouterModule, SignupPageComponent],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})

export class LoginPageComponent {
  //RegisterUser: FormGroup;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    const RegisterUser = new FormGroup
      ({
        PhoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
        Password: new FormControl('', [Validators.required, Validators.minLength(8)])

      });
  }

  LoginMethod() {
    //method to do when login click values happen to be a success  i.e. to the track expense/ home page
  }
}
