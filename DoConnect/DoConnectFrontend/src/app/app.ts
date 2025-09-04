import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from './pages/reusable/footer/footer';
import { Header } from './pages/reusable/header/header';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Footer, Header],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('DoConnectFrontend');
}
