import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { Data } from '@angular/router';
import { CommonModule, NgFor } from '@angular/common';

@Component({
  selector: 'app-posts',
  imports: [
    CommonModule, // Import CommonModule here
    NgFor, // NgFor is part of CommonModule, but explicitly listing it for clarity
  ],
  templateUrl: './posts.component.html',
  styleUrl: './posts.component.css',
})
export class PostsComponent {
  posts: any[] = [];

  constructor(private dataService: DataService) {
    this.dataService.getPost().subscribe((data: any[]) => {
      this.posts = data;
    });
  }
}
