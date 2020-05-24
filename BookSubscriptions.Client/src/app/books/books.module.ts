import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { BooksComponent } from './books.component';


import { SharedModule } from '../shared/modules/shared.module';


@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: BooksComponent
      },
    ])
  ],
  declarations: [
    BooksComponent
  ]
})
export class BooksModule { }
