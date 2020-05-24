import { Component } from '@angular/core';
import { UserService } from './shared/services/user.service';
import { slideInAnimation } from './app.animation';
import {
  Router,
  Event,
  NavigationStart,
  NavigationEnd,
  NavigationError,
  NavigationCancel,
} from '@angular/router';
import { MessageService } from './messages/messages.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [slideInAnimation],
})
export class AppComponent {
  pageTitle = 'Book Subscriptions';
  loading = true;

  get isLoggedIn(): boolean {
    return this.userService.isLoggedIn;
    return false;
  }

  get isMessageDisplayed(): boolean {
    //return this.messageService.isDisplayed;
    return false;
  }

  get userName(): string {
    // if (this.authService.currentUser) {
    //   return this.authService.currentUser.userName;
    // }
    return '';
  }

  constructor(
    private userService: UserService,
    private router: Router,
    private messageService: MessageService
  ) {
    router.events.subscribe((routerEvent: Event) => {
      this.checkRouterEvent(routerEvent);
    });
  }

  checkRouterEvent(routerEvent: Event): void {
    if (routerEvent instanceof NavigationStart) {
      this.loading = true;
    }

    if (
      routerEvent instanceof NavigationEnd ||
      routerEvent instanceof NavigationCancel ||
      routerEvent instanceof NavigationError
    ) {
      this.loading = false;
    }
  }

  displayMessages(): void {
    this.router.navigate([{ outlets: { popup: ['messages'] } }]); // Works
    this.messageService.isDisplayed = true;
  }

  hideMessages(): void {
    this.router.navigate([{ outlets: { popup: null } }]);
    this.messageService.isDisplayed = false;
  }

  logOut(): void {
    this.userService.logout();
    this.router.navigateByUrl('/home');
  }
}
