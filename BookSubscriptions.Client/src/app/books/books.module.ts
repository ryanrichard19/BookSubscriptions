import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { BooksComponent } from './books.component';


import { SharedModule } from '../shared/modules/shared.module';
import { BookDetailsComponent } from './book-details.component';
import { BookResolver } from './book-resolver-service';
import { StarComponent } from '../star/star.component';


@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: BooksComponent
      },
      {
        path: ':id',
        component: BookDetailsComponent,
        resolve: { resolvedData: BookResolver }
      }
    ])
  ],
  declarations: [
    BooksComponent,
    BookDetailsComponent,
    StarComponent
  ]
})
export class BooksModule { }
