import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Event } from '../../models/event';
import { EventDataService } from '../../services/event-data';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-event-details',
  imports: [FormsModule, NgForOf],
  templateUrl: './event-details.html',
  styleUrl: './event-details.css',
})
export class EventDetails {
  constructor(private eventService: EventDataService) {}

  searchId: number = 0;
  onlineFilter: boolean | null = null;
  filteredEvents: Event[] = [];

  findById() {
    this.filteredEvents = [];
    this.eventService.getEventById(this.searchId).subscribe((data) => {
      this.filteredEvents = [data];
    });
  }
}
