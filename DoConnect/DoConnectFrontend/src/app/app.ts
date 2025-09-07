import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from './pages/reusable/footer/footer';
import { Header } from './pages/reusable/header/header';
import { notificationService } from './services/notification-service';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Footer, Header],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('DoConnectFrontend');

  constructor() {
    if (notificationService.hasNewNotifications) {
      // You can add global notification handling logic here if needed
    }
  }
}
