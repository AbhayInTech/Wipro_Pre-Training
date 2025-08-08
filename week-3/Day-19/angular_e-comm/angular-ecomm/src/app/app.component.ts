import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductCardComponent } from './product-card/product-card.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ProductCardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'angular-ecomm';
}
