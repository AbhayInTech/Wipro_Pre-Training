import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { DestinationService } from '../services/destination';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-destination',
  imports: [NgFor],
  templateUrl: './destination.html',
  styleUrl: './destination.css',
})
export class Destination implements OnInit {
  destinations: any[] = [];

  constructor(private destinationService: DestinationService) {}

  ngOnInit(): void {
    this.destinationService
      .getDestinations('destination') // replace 'places' with your actual endpoint
      .subscribe({
        next: (data) => (this.destinations = data),
        error: (err) => console.error('API error:', err),
      });
  }
}
