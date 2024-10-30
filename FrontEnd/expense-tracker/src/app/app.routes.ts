import { Routes } from '@angular/router';
import { LoginPageComponent } from '../login-page/login-page.component';
import { SignupPageComponent } from '../signup-page/signup-page.component';
import { ViewProfileComponent } from '../view-profile/view-profile.component';

export const routes: Routes =
 [
    {path:'', component:LoginPageComponent},
    {path:'login-page',component:LoginPageComponent},
    {path: 'signup-page',component:SignupPageComponent},
    {path:'view-profile',component:ViewProfileComponent}
];
