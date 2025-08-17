import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { EventDataService } from '../../services/event-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-create',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './event-create.html',
  styleUrl: './event-create.css',
})
export class EventCreate {
  constructor(private eventService: EventDataService, private router: Router) {}

  onSubmit(form: NgForm): void {
    const newEvent: any = {
      ...form.value,
      isOnline: form.value.mode === 'online',
      id: (Math.floor(Math.random() * 101) + 100).toString(),
      organizer: 'EventManager Team',
      category: 'General',
      status: 'Upcoming',
    };

    console.log('New Event:', newEvent);

    this.eventService.createEvent(newEvent).subscribe({
      next: () => this.router.navigate(['/events']),
      error: (err) => console.error('POST failed:', err),
    });
  }
}
