import { FormControl } from "@angular/forms";

export interface IRegister 
{
 Name:FormControl<string|null>;
 Phone:FormControl<string|null>;
 Password:FormControl<string|null>;
 Cpassword:FormControl<string|null>;
 
}
