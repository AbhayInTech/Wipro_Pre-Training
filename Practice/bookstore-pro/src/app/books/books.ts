import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule, AsyncPipe } from '@angular/common';
import { Subscription, Observable } from 'rxjs';
import { DataService } from '../services/data';
import { BookCard } from '../book-card/book-card';
import { DatePipe, CurrencyPipe, UpperCasePipe, SlicePipe } from '@angular/common';
import { DiscountPipe } from '../pipes/discount-pipe-pipe';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [
    CommonModule,
    AsyncPipe,
    DatePipe,
    CurrencyPipe,
    UpperCasePipe,
    SlicePipe, // ✅ add this

    DiscountPipe,
    BookCard,
  ],
  templateUrl: 'books.html',
  styleUrls: ['books.css'],
})
export class Books implements OnInit, OnDestroy {
  books$!: Observable<any[]>;
  sub!: Subscription;
  books: any[] = [];

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.books$ = this.dataService.getBooks();
    this.sub = this.books$.subscribe((data) => (this.books = data));
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
