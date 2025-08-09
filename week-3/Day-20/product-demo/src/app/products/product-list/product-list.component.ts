import { Component } from '@angular/core';
import { Product } from '../../models/product.model';
import { PriceFormatPipe } from '../../pipes/price-format.pipe';
import { NgModule } from '@angular/core';
import { HighlightDirective } from '../../directives/highlight.directive';
import { NgIf, NgClass, NgFor } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
//adding your interface based on product.model.ts

@Component({
  selector: 'app-product-list',
  imports: [
    PriceFormatPipe,
    HighlightDirective,
    NgIf,
    NgClass,
    NgFor,
    BrowserModule,
  ],
  standalone: true,
  providers: [],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent {
  Productss: Product[] = [
    {
      id: 1,
      name: 'Laptop',
      price: 1000,
      inStock: true,
      description: 'High performance laptop',
    },
    {
      id: 2,
      name: 'Smartphone',
      price: 500,
      inStock: true,
      description: 'Latest model smartphone',
    },
    {
      id: 3,
      name: 'Tablet',
      price: 300,
      inStock: false,
      description: 'Portable tablet device',
    },
    {
      id: 4,
      name: 'Smartwatch',
      price: 200,
      inStock: true,
      description: 'Feature-rich smartwatch',
    },
    {
      id: 5,
      name: 'Headphones',
      price: 100,
      inStock: true,
      description: 'Noise-cancelling headphones',
    },
    {
      id: 6,
      name: 'Camera',
      price: 1200,
      inStock: true,
    },
  ];
}
