import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent {
  errorMessage: string;
  pageTitle = 'Log In';

  constructor(
    private userService: UserService,
    private router: Router
  ) {}

  login(loginForm: NgForm) {
    if (loginForm && loginForm.valid) {
      const email = loginForm.form.value.email;
      const password = loginForm.form.value.password;
      this.userService.login(email, password)
      .subscribe(
        (result) => {
          if (result) {
            if (this.userService.isLoggedIn) {
              this.router.navigate(['/books']);
            } else {
              this.router.navigate(['']);
            }
          }
        },
        (errors) => (this.errorMessage = 'Please enter a email and password.')
      );
    }
  }
}
