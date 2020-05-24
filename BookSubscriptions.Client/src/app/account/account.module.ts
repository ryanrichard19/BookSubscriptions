import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/modules/shared.module';

import { UserService } from '../shared/services/user.service';

// import { EmailValidator } from '../directives/email.validator.directive';

import { routing } from './account.routing';

@NgModule({
  declarations: [RegistrationFormComponent, LoginFormComponent],
  providers: [UserService],
  imports: [CommonModule, FormsModule, routing, SharedModule],
})
export class AccountModule {}
