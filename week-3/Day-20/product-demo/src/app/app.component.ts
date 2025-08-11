import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProductListComponent } from './products/product-list/product-list.component';
import { PriceFormatPipe } from './pipes/price-format.pipe';
import { HighlightDirective } from './directives/highlight.directive';
<<<<<<< HEAD

=======
@NgModule({
  declarations: [PriceFormatPipe, HighlightDirective, ProductListComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent],
})
>>>>>>> cad057829a00b82a8a1098b48ce57038d63cda17
@Component({
  selector: 'app-root',
  imports: [ProductListComponent, PriceFormatPipe, HighlightDirective],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
})
<<<<<<< HEAD
// @NgModule({
//   declarations: [PriceFormatPipe, HighlightDirective, ProductListComponent],
//   imports: [BrowserModule],
//   providers: [],
//   bootstrap: [AppComponent],
// })
=======
>>>>>>> cad057829a00b82a8a1098b48ce57038d63cda17
export class AppComponent {
  title = 'product-demo';
}
