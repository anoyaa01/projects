import { FormControl } from "@angular/forms";

export interface IExpenseInterface {

     Amount: FormControl<number| null>;
     Description: FormControl<string | null>;
     Category: FormControl<string | null>;
     Id: FormControl<number | null>;
}