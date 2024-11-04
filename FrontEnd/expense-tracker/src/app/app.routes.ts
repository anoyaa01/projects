import { Routes } from '@angular/router';
import { LoginPageComponent } from '../login-page/login-page.component';
import { SignupPageComponent } from '../signup-page/signup-page.component';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { TrackExpenseComponent } from '../track-expense/track-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';

export const routes: Routes =
 [
    {path:'', component:LoginPageComponent},
    {path:'login-page',component:LoginPageComponent},
    {path: 'signup-page',component:SignupPageComponent},
    {path:'view-profile',component:ViewProfileComponent},
    {path: 'category-expense',component:CategoryExpenseComponent},
    {path: 'track-expense', component:TrackExpenseComponent},
    {path:'add-expense', component:AddExpenseComponent}
];
