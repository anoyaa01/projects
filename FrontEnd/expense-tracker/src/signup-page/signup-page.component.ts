import { Component } from '@angular/core';
import { IRegister } from '../i-register.interface';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-signup-page',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.scss'
})
export class SignupPageComponent {

  RegisterUser!: FormGroup<IRegister>;
  password: string = '';
  registerSubmitted: boolean = false;

/**
 *
 */
constructor(private http:HttpClient) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.RegisterUser = new FormGroup<IRegister>
      ({
        Name: new FormControl('', Validators.required),
        Phone: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
        Password: new FormControl('', [Validators.required, Validators.minLength(8)]),
        Cpassword: new FormControl('', [Validators.required, Validators.minLength(8)])
      });
  }
  AddNewUser() {
    this.registerSubmitted = true;
    if (this.RegisterUser.valid) {
      console.log("User registered successfully");
      const addNewUser = {
        Name: this.RegisterUser.value.Name,
        Phone: this.RegisterUser.value.Phone,
        Password: this.RegisterUser.value.Password,
      }

      this.http.post('http://localhost:5277/api/Users',addNewUser)
      .subscribe({
        next:(value)=>
        {
          console.log(value);
          this.RegisterUser.reset();
        },
        error: (err) => {
          console.error('Registration error:', err);
        }
      })
    }
  }
}
