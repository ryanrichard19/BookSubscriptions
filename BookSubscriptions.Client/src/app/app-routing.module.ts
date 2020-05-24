import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegistrationFormComponent } from './account/registration-form/registration-form.component';
import { PageNotFoundComponent } from './page-not-found.component';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { BooksComponent } from './books/books.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'books', component: BooksComponent },
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
