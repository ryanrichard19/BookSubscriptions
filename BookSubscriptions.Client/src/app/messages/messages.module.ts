import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared/modules/shared.module';

import { MessagesComponent } from './messages.component';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: 'messages',
        component: MessagesComponent,
        outlet: 'popup'
      }
    ])
  ],
  declarations: [
    MessagesComponent
  ]
})
export class MessageModule { }