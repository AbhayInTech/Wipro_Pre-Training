import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EventDataService } from '../../services/event-data';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-event-create',
  imports: [ReactiveFormsModule],
  templateUrl: './event-create.html',
  styleUrl: './event-create.css',
})
export class EventCreate implements OnInit {
  eventForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private eventService: EventDataService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.eventForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      date: ['', Validators.required],
      location: ['', Validators.required],
      isOnline: ['online', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.eventForm.valid) {
      const newEvent = {
        ...this.eventForm.value,
        isOnline: this.eventForm.value.isOnline === 'online',
        id: Date.now().toString(), // simple unique ID
        attendeesCount: 0,
        organizer: 'EventManager Team',
        category: 'General',
        tags: [],
        status: 'Upcoming',
      };

      console.log('New Event:', newEvent);

      this.eventService.createEvent(newEvent).subscribe({
        next: () => this.router.navigate(['/events']),
        error: (err) => console.error('POST failed:', err),
      });
    }
  }
}
