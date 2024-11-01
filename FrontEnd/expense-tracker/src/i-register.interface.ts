import { FormControl } from "@angular/forms";

export interface IRegister 
{
 Name:FormControl<string|null>;
 PhoneNumber:FormControl<string|null>;
 Password:FormControl<string|null>;
 Cpassword:FormControl<string|null>;
 
}
