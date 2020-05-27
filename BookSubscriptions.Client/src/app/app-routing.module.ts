import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegistrationFormComponent } from './account/registration-form/registration-form.component';
import { PageNotFoundComponent } from './page-not-found.component';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { BooksComponent } from './books/books.component';
import { SelectiveStrategy } from './selective-strategy.service';


const routes: Routes = [

  { path: 'home', component: HomeComponent },
  {
    path: 'books',
    data: { preload: false },
    loadChildren: () =>
      import('./books/books.module').then(m => m.BooksModule)
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      {
        path: 'books',
        data: { preload: false },
        loadChildren: () =>
          import('./books/books.module').then(m => m.BooksModule)
      },
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', component: PageNotFoundComponent }
      ], { enableTracing: true, preloadingStrategy: SelectiveStrategy })
],
exports: [RouterModule]
})
export class AppRoutingModule { }
