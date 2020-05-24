import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { UserRegistration } from '../models/user.registration.interface';
import { ConfigService } from '../configs/config.service';

import { BaseService } from './base.service';

import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class UserService extends BaseService {
  baseUrl = '';

  private authNavStatusSource = new BehaviorSubject<boolean>(false);

  private loggedIn = false;

  get isLoggedIn(): boolean {
    return this.loggedIn;
  }

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this.authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

  register(user: UserRegistration): Observable<UserRegistration> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .post<UserRegistration>(this.baseUrl + '/Accounts', user, {
        headers,
      })
      .pipe(
        tap((data) =>
          console.log('User Registration: ' + JSON.stringify(data))
        ),
        catchError(this.handleError)
      );
  }

  login(email, password) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .post(
        this.baseUrl + '/auth/login',
        JSON.stringify({ email, password }),
        { headers }
      )
      .pipe(
        tap((res: any) => {
          localStorage.setItem('auth_token', res.authToken);
          this.loggedIn = true;
          this.authNavStatusSource.next(this.loggedIn);
          return true;
        }),
        catchError(this.handleError)
      );
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this.authNavStatusSource.next(this.loggedIn);
  }

}
