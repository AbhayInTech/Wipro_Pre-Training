import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Parent } from './parent/parent';
import { DataService } from './data-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Parent],
  providers: [DataService],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('Demo_Observable');
}
