import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/shared/models/book';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../shared/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss'],
})
export class BooksComponent implements OnInit {
  pageTitle = 'Book List';

  errorMessage = '';

  _listFilter = '';

  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredBooks = this.listFilter
      ? this.performFilter(this.listFilter)
      : this.books;
  }

  filteredBooks: Book[] = [];
  books: Book[] = [];

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.listFilter = this.route.snapshot.queryParamMap.get('filterBy') || '';
    this.bookService.getBooks().subscribe({
      next: (books) => {
        this.books = books;
        this.filteredBooks = this.performFilter(this.listFilter);
      },
      error: (err) => (this.errorMessage = err),
    });
  }

  performFilter(filterBy: string): Book[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.books.filter(
      (book: Book) => book.title.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
}

