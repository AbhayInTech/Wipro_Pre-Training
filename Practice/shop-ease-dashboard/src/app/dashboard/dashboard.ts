import { Component } from '@angular/core';
import { Product } from '../models/product';
import { ProductDetails } from '../product-details/product-details';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [ProductDetails, NgFor, NgIf],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  products: Product[] = [
    { name: 'Laptop', price: 75000 },
    { name: 'Smartphone', price: 25000 },
    { name: 'Headphones', price: 2000 },
  ];

  selectedProduct?: Product;
  feedbackList: string[] = [];

  selectProduct(product: Product) {
    this.selectedProduct = product;
  }

  receiveFeedback(feedback: string) {
    this.feedbackList.push(feedback);
  }
}
