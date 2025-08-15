import { Component } from '@angular/core';
import { PriceFormatPipe } from '../../../pipes/price-format-pipe';
import { CommonModule, DatePipe, NgFor } from '@angular/common';
import { trigger, style, animate, transition } from '@angular/animations';
import { Highlight } from '../../../directives/highlight';

interface Event {
  name: string;
  date: string;
  price: number;
  category: string;
}

@Component({
  selector: 'app-event-list',
  imports: [NgFor, CommonModule, PriceFormatPipe, Highlight, DatePipe],
  templateUrl: './event-list.html',
  styleUrl: './event-list.css',
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('500ms ease-in', style({ opacity: 1 })),
      ]),
    ]),
  ],
})
export class EventList {
  events: Event[] = [
    { name: 'Tech Innovators Conference', date: '2025-09-12', price: 3500, category: 'Conference' },
    { name: 'Creative Writing Workshop', date: '2025-10-05', price: 800, category: 'Workshop' },
    { name: 'Rock Music Concert', date: '2025-11-20', price: 2500, category: 'Concert' },
    {
      name: 'AI & Machine Learning Summit',
      date: '2025-12-02',
      price: 5000,
      category: 'Conference',
    },
  ];
}
