import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterOutlet } from '@angular/router';
import { DataService } from './data.service';
import { PostsComponent } from './posts/posts.component';
import { NgFor, NgIf } from '@angular/common';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    BrowserModule,
    HttpClientModule,
    NgFor,
    NgIf,
    PostsComponent,
    CommonModule, // Import CommonModule to use directives like NgFor
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  protected readonly title = 'Http-Observables-demo';
  posts$: any;

  constructor(private dataService: DataService) {
    this.posts$ = this.dataService.getPost();
    this.posts$.subscribe((data: any) => {
      console.log(data);
    });
  }
}
