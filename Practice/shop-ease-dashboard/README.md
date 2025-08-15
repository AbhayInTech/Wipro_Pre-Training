# ShopEase Dashboard – Angular Component Communication

## 📖 Overview

This Angular application is a **Day 21 Case Study Assignment** implementation for learning **component communication** in Angular.  
It demonstrates **parent-to-child** and **child-to-parent** communication using `@Input()` and `@Output()` decorators.

The app is a simple **product dashboard** where:

- The **Dashboard** component (parent) displays a list of products.
- When a user clicks on a product, details are passed to the **ProductDetails** component (child) using `@Input()`.
- In the **ProductDetails** component, the user can give feedback.
- The feedback is sent back to the Dashboard using `@Output()` with `EventEmitter`.
- The Dashboard displays the feedback instantly without reloading the page.

---

## 📌 Features

- **Parent-to-Child communication** via `@Input()`  
  Dashboard → ProductDetails (selected product details)
- **Child-to-Parent communication** via `@Output()`  
  ProductDetails → Dashboard (user feedback)
- Real-time update of the feedback list
- Clean and simple UI to focus on logic

---

## 📂 Project Structure

src/
├── app/
│ ├── dashboard/
│ │ ├── dashboard.component.ts
│ │ ├── dashboard.component.html
│ │ ├── dashboard.component.css
│ ├── product-details/
│ │ ├── product-details.component.ts
│ │ ├── product-details.component.html
│ │ ├── product-details.component.css
│ ├── models/
│ │ ├── product.ts
│ ├── app.module.ts
│ ├── app.component.ts
│ ├── app.component.html

yaml
Copy code

---

## 🛠️ Installation & Setup

### **1. Install Node.js and npm**

Make sure you have Node.js installed. Check with:

```bash
node -v
npm -v
If not installed, download from: https://nodejs.org/

2. Install Angular CLI
bash
Copy code
npm install -g @angular/cli
3. Clone the Project
If you have the project zip, extract it. If hosted on GitHub:

bash
Copy code
git clone <repository-url>
cd shop-ease-dashboard
4. Install Dependencies
bash
Copy code
npm install
5. Run the Application
bash
Copy code
ng serve
Open a browser and go to:

arduino
Copy code
http://localhost:4200
🧩 How It Works
Dashboard Component (Parent)
Holds the list of products in a products array.

Handles click events to set selectedProduct.

Displays the ProductDetails child component when a product is selected.

Receives feedback from the child and pushes it into feedbackList.

ts
Copy code
// dashboard.component.ts
selectProduct(product: Product) {
  this.selectedProduct = product;
}

receiveFeedback(feedback: string) {
  this.feedbackList.push(feedback);
}
ProductDetails Component (Child)
Uses @Input() to receive product details from Dashboard.

Has a textarea for user feedback bound with [(ngModel)].

Uses @Output() with EventEmitter to send feedback back to the parent.

ts
Copy code
// product-details.component.ts
@Input() product!: Product;
@Output() feedback = new EventEmitter<string>();

sendFeedback() {
  if (this.userFeedback.trim()) {
    this.feedback.emit(this.userFeedback);
    this.userFeedback = '';
  }
}
Data Flow
Parent to Child (@Input)

Dashboard passes selected product:

html
Copy code
<app-product-details
  *ngIf="selectedProduct"
  [product]="selectedProduct!"
  (feedback)="receiveFeedback($event)">
</app-product-details>
Child to Parent (@Output)

ProductDetails emits feedback:

ts
Copy code
this.feedback.emit(this.userFeedback);


--------- Abhay Rana
```
