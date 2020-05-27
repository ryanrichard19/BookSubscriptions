import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { BookResolved } from '../shared/models/book';
import { BookService } from '../shared/services/book.service';

@Injectable({
  providedIn: 'root'
})
export class BookResolver implements Resolve<BookResolved> {

  constructor(private bookService: BookService) { }

  resolve(route: ActivatedRouteSnapshot,
          state: RouterStateSnapshot): Observable<BookResolved> {
    const id = route.paramMap.get('id');
    if (isNaN(+id)) {
      const message = `Book id was not a number: ${id}`;
      console.error(message);
      return of({ book: null, error: message });
    }

    return this.bookService.getBook(+id)
      .pipe(
        map(book => ({ book })),
        catchError(error => {
          const message = `Retrieval error: ${error}`;
          console.error(message);
          return of({ book: null, error: message });
        })
      );
  }

}
