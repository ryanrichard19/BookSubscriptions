import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutofocusDirective } from '../../directives/auto-focus.directive';
import { FormsModule } from '@angular/forms';



@NgModule({
  imports: [CommonModule],
  declarations: [AutofocusDirective],
  exports: [
    AutofocusDirective,
    CommonModule,
    FormsModule
  ],
  providers: [],
})
export class SharedModule {}
