import { Component } from '@angular/core';

interface Product {
  productName: string;
  productPrice: number;
  addedToCart: boolean;
}
@Component({
  selector: 'app-product-card',
  imports: [],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css',
})
export class ProductCardComponent {
  products: Product[] = [
    { productName: 'Apple iPhone 14', productPrice: 99.99, addedToCart: false },
    {
      productName: 'Samsung Galaxy S23',
      productPrice: 89.99,
      addedToCart: false,
    },
    { productName: 'Google Pixel 7', productPrice: 79.99, addedToCart: false },
  ];

  addToCart(index: number) {
    this.products[index].addedToCart = true;
    console.log(
      `${this.products[index].productName} has been added to the cart.`
    );
  }
}
