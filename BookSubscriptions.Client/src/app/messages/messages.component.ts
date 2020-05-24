import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { MessageService } from './messages.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss'],
})
export class MessagesComponent implements OnInit {
  constructor(private messageService: MessageService, private router: Router) {}

  ngOnInit(): void {}

  get messages() {
    return this.messageService.messages;
  }

  close(): void {
    // Close the popup.
    this.router.navigate([{ outlets: { popup: null } }]);
    this.messageService.isDisplayed = false;
  }
}
