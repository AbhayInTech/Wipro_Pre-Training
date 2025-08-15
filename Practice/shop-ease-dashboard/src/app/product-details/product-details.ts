import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../models/product';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.html',
  imports: [CommonModule, FormsModule],
  styleUrl: './product-details.css',
})
export class ProductDetails {
  @Input() product!: Product;
  @Output() feedback = new EventEmitter<string>();

  userFeedback: string = '';

  sendFeedback() {
    if (this.userFeedback.trim()) {
      this.feedback.emit(this.userFeedback);
      this.userFeedback = '';
    }
  }
}
