import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Dashboard } from './dashboard/dashboard';

@Component({
  selector: 'app-root',
  imports: [FormsModule, CommonModule, Dashboard],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('shop-ease-dashboard');
}
