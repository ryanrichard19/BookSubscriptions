import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserRegistration } from 'src/app/shared/models/user.registration.interface';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss'],
})
export class RegistrationFormComponent implements OnInit {
  success: boolean;
  errors: string;
  isRequesting: boolean;
  submitted = false;
  userRegistration: UserRegistration = {
    FirstName: '',
    LastName: '',
    Email: '',
    Password: '',
  };

  constructor(
    private userService: UserService,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {}

  ngOnInit(): void {}
  onSubmit() {
    this.spinner.show();
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';

    this.userService
      .register(this.userRegistration)
      .pipe(
        finalize(() => {
          this.isRequesting = false;
        })
      )
      .subscribe(
        (result) => {
          if (result) {
            this.router.navigate(['/login'], {
              queryParams: {
                brandNew: true,
                email: this.userRegistration.Email,
              },
            });
          }
        },
        (errors) => (this.errors = errors)
      );
  }
}
