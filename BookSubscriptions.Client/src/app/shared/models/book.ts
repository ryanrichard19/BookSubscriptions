export interface Book {
    id: number;
    title: string;
    author: string;
    price: number;
    description: string;
    starRating: number;
  }


  export interface BookResolved {
    book: Book;
    error?: any;
  }