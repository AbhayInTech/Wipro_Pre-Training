import { Component, OnInit } from '@angular/core';
import { DataService } from '../data-service';
import { inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-parent',
  imports: [CommonModule, HttpClientModule],
  templateUrl: './parent.html',
  styleUrl: './parent.css',
})
export class Parent implements OnInit {
  posts: any[] = [];
  dataservice = inject(DataService);

  ngOnInit(): void {
    this.dataservice.getPost().subscribe(
      (data: any[]) => {
        this.posts = data;
        console.log(this.posts);
      },
      (error) => {
        console.error('Error fetching posts:', error);
      }
    );
  }
}
