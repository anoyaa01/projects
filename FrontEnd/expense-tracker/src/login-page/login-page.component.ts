import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterModule, RouterOutlet, Routes } from '@angular/router';
import { SignupPageComponent } from '../signup-page/signup-page.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IRegister } from '../i-register.interface';
import { CustomerServiceService } from '../customer-service.service';
import { UserIdService } from '../user-id.service';


@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [RouterOutlet, RouterLinkActive, RouterLink, RouterModule, SignupPageComponent,ReactiveFormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})

export class LoginPageComponent {
  loginForm!: FormGroup;
  constructor(private customerService : CustomerServiceService, private userIdService : UserIdService,private router:Router) {}
  ngOnInit(): void {
      this.loginForm = new FormGroup
      ({
        phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
        password: new FormControl('', [Validators.required, Validators.minLength(8)])

      });
  }

  Login() {
    if(this.loginForm.valid){
      const userData = 
      {
        phone: this.loginForm.value.phoneNumber,
        password:this.loginForm.value.password
      }
      this.customerService.checkUserDetails(userData).subscribe({
        next: (data) => {
          if(data!==0){
          console.log("user id is",data);
          this.userIdService.setUserId(data);
          this.router.navigate(['/track-expense']);
          }
          else{
            alert("Invalid Username or Password");
          }
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
  }
}