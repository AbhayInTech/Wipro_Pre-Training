// Remove unused and invalid imports

import { Component, signal } from '@angular/core';
import { EventList } from './components/event-list/event-list/event-list';

@Component({
  selector: 'app-root',
  imports: [EventList],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('EMA');
}
