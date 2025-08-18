# Book Management REST API

## Features

- Initialize project with **npm** and dependencies
- Setup Express.js server with routes
- Store books in a JSON file using `fs` module
- CRUD operations (Create, Read, Update, Delete)
- Use of async for non-blocking file I/O
- EventEmitter to log book operations
- Tested with Postman

---

## Project Structure

```
book-api/
├── data/
│   └── books.json          # JSON file
├── services/
│   └── bookService.js      # Utility functions for reading/writing books
├── server.js               # Main entry point (Express server & routes)
├── package.json            # Dependencies and scripts
├── package-lock.json
└── README.md               # Documentation
```

---

## Installation & Setup

### 1. Clone the Repository

git clone <repo-url>
cd book-api

### 2. Initialize Project

npm init -y

### 3. Install Dependencies

npm install express
npm install --save-dev nodemon

### 4. Update `package.json`

Add this in the `"scripts"` section:

"scripts": {
"start": "nodemon server.js"
}

## Running the Application

npm start

Server will start on:

```
http://localhost:3000
```

---

## API Endpoints

### Root

**GET /**

```json
{
  "message": "Welcome to Book Management API"
}
```

### Get All Books

**GET /books**
Returns a list of all books.

**Response Example:**

```json
[
  { "id": 169221, "title": "The Alchemist", "author": "Paulo Coelho" },
  { "id": 169222, "title": "Atomic Habits", "author": "James Clear" }
]
```

### Get Book by ID

**GET /books/\:id**
Returns a single book if found, otherwise 404.

**Example:**
`GET /books/169221`

**Response:**

```json
{ "id": 169221, "title": "The Alchemist", "author": "Paulo Coelho" }
```

### Add a New Book

**POST /books**
Body (JSON):

```json
{
  "title": "Rich Dad Poor Dad",
  "author": "Robert Kiyosaki"
}
```

**Response:**

```json
{
  "id": 169223,
  "title": "Rich Dad Poor Dad",
  "author": "Robert Kiyosaki"
}
```

Logs:

```
Book Added: { id: 169223, title: 'Rich Dad Poor Dad', author: 'Robert Kiyosaki' }
```

### Update a Book

**PUT /books/\:id**
Body (JSON):

```json
{
  "title": "Rich Dad Poor Dad - Updated",
  "author": "Robert Kiyosaki"
}
```

**Response:**

```json
{
  "id": 169223,
  "title": "Rich Dad Poor Dad - Updated",
  "author": "Robert Kiyosaki"
}
```

Logs:

```
Book Updated: { id: 169223, title: 'Rich Dad Poor Dad - Updated', author: 'Robert Kiyosaki' }
```

### Delete a Book

**DELETE /books/\:id**

**Response:**

```json
{ "message": "Book deleted" }
```

Logs:

```
Book Deleted: 169223
```

## Asynchronous Programming

- File operations (`readFile`, `writeFile`) use **async/await**
- Prevents blocking the Node.js event loop

---

## Event Logging

The app uses **EventEmitter** to log key actions:

- Book Added
- Book Updated
- Book Deleted

---

## Testing the API

### Using **curl**

```bash
# Get all books
curl http://localhost:3000/books



### Using **Postman**

1. Open Postman
2. Create requests with above endpoints
3. Set **Content-Type: application/json** for POST/PUT

---

## Submission Guidelines

* **Dependencies:** `"express"` in dependencies, `"nodemon"` in devDependencies
* **Scripts:** `"start": "nodemon server.js"`
* **Code Style:** ES6+, async/await, try/catch error handling
* **Testing:** Test all CRUD routes with Postman or curl
* **Documentation:** This README includes setup & API docs

---

## Conclusion

This project demonstrates a complete Node.js REST API with:

* Express.js server
* File handling with `fs`
* CRUD routes
* Async/await for non-blocking operations
* EventEmitter for logging
```
