import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { Book } from 'src/app/shared/models/book';
import { BaseService } from './base.service';
import { ConfigService } from '../configs/config.service';

@Injectable({
  providedIn: 'root',
})
export class BookService extends BaseService {
  private booksUrl = '/book';
  baseUrl = '';
  public books: Book[];

  constructor(
    private http: HttpClient,
    private configService: ConfigService
    ) {
    super();
    this.baseUrl = configService.getApiURI();
  }
  

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + this.booksUrl).pipe(
      tap((data) => {
        this.books = data;
      }),
      catchError(this.handleError)
      );
    }


 
}
