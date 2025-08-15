import { Component, Input } from '@angular/core';
import { UpperCasePipe, CurrencyPipe, DatePipe, SlicePipe } from '@angular/common';
import { DiscountPipe } from '../pipes/discount-pipe-pipe';

@Component({
  selector: 'app-book-card',
  templateUrl: 'book-card.html',
  styleUrls: ['book-card.css'],
  imports: [UpperCasePipe, CurrencyPipe, DatePipe, SlicePipe, DiscountPipe],
  standalone: true,
})
export class BookCard {
  @Input() book: any;
}
