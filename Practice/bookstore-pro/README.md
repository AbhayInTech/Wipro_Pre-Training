📚 BookStore Pro — Angular Pipes & Components Demo

This is an Angular 17 project that demonstrates the use of built-in pipes, a custom pipe, HTTP communication, interceptors, and component interaction.
It’s structured to serve as a learning and showcase project.

🎯 Features

4 Built-in Pipes

DatePipe → Formats and displays the publication date of a book.

CurrencyPipe → Displays the book price in Indian Rupees (₹).

UpperCasePipe → Converts the book title to uppercase.

SlicePipe → Shows only the first 50 characters of a book’s description.

1 Custom Pipe

DiscountPipe → Calculates and displays the discounted book price.

AsyncPipe & manual subscription for displaying API data.

HTTP Interceptor to attach an Authorization header to requests.

Parent → Child component communication using @Input().

Responsive UI styling for better presentation.

🗂 Project Structure (Simplified)
src/app
│
├── app.ts / app.html / app.css # Root component
│
├── books/ # Parent component for displaying books
│
├── book-card/ # Child component for individual book display
│
├── pipes/discount.pipe.ts # Custom discount pipe
│
├── interceptor/auth-interceptor.ts # HTTP request interceptor
│
└── data.service.ts # Service for API calls

📦 How It Works

1. Data Fetching

The project uses an Angular service (data.service.ts) to fetch book data from a mock API.

Data is fetched in two ways:

AsyncPipe → Automatically subscribes and displays data in the template.

Manual subscription → Subscribes in ngOnInit() and stores the result in a local variable.

2. Custom Pipe

DiscountPipe calculates the price after applying a discount percentage.

Integrated alongside Angular’s built-in pipes for combined transformations.

3. Parent & Child Components

The Books component fetches the data and passes each book object to the BookCard component.

BookCard handles displaying details with formatting pipes.

4. HTTP Interceptor

AuthInterceptor attaches a dummy Authorization token to every outgoing request for demonstration.

5. Styling

Components have scoped CSS for layout and formatting.

Minimal, clean UI focusing on readability.

📌 Demonstrated Concepts
Feature Purpose
DatePipe Format publication date
CurrencyPipe Show price in INR
UpperCasePipe Convert title to uppercase
SlicePipe Limit description to 50 chars
Custom Pipe (DiscountPipe) Apply discount to price
AsyncPipe Stream API data without manual unsubscribe
HTTP Interceptor Add auth header to requests
Parent-Child Components Data sharing via @Input
🚀 Running the Project

Install Angular CLI (if not installed)

npm install -g @angular/cli

Install dependencies

npm install

Run the development server

ng serve

Open browser → http://localhost:4200

🖼 Output Example

Main Page: Displays book list in two sections:

Books displayed using AsyncPipe

Books displayed using manual subscription

Each book card shows:

Title (uppercase)

Price (₹)

Discounted Price (₹)

Publication Date

Short Description (50 chars)
