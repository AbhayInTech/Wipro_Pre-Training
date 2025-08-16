import { Component, OnInit } from '@angular/core';
import { EventDataService } from '../../services/event-data';
import { Event } from '../../models/event';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-event-list',
  imports: [CommonModule, RouterLink],
  templateUrl: './event-list.html',
  styleUrl: './event-list.css',
})
export class EventList implements OnInit {
  events: Event[] = [];

  constructor(private eventService: EventDataService) {}

  ngOnInit(): void {
    this.eventService.getEvents().subscribe((data) => {
      this.events = data;
    });
  }
}
