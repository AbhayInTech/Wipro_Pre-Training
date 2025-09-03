import { CommonModule, NgIf } from '@angular/common';
import { Component, signal } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-root',
  imports: [CommonModule, NgIf],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('simple-axios-demo');
  user: any = null;

  loading = false;

  error = '';

  async getData() {
    this.loading = true;

    this.error = '';

    try {
      // Using Random User API
      const response = await axios.get('https://randomuser.me/api/');

      this.user = response.data.results[0];
    } catch (err) {
      this.error = 'Failed to fetch user data';

      console.error(err);
    } finally {
      this.loading = false;
    }
  }
}
