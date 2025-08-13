import { Component } from '@angular/core';
import { DataService } from '../data-service';
import { OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-parent',
  imports: [],
  templateUrl: './parent.html',
  styleUrl: './parent.css',
})
export class Parent implements OnInit {
  ngOnInit(): void {
    this.dataservice.getPost().subscribe((data: any) => {
      console.log(data);
      this.posts = data;
    });
  }
  dataservice = inject(DataService);
  posts: any[] = [];
}
