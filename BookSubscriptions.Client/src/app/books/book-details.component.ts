import { Component, OnInit } from '@angular/core';
import { Book, BookResolved } from '../shared/models/book';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent implements OnInit {
  pageTitle = 'Book Detail';
  book: Book;
  errorMessage: string;

  constructor(

    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const resolvedData: BookResolved = this.route.snapshot.data.resolvedData;
    this.errorMessage = resolvedData.error;
    this.onProductRetrieved(resolvedData.book);
  }

  onProductRetrieved(book: Book): void {
    this.book = book;

    if (this.book) {
      this.pageTitle = `Book Detail: ${this.book.title}`;
    } else {
      this.pageTitle = 'No book found';
    }
  }

}
