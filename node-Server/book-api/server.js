// const express = require("express");
// const app = express();

// app.use(express.json());

// const PORT = 3000;

// app.get("/", (req, res) => {
//   res.json({ message: "Welcome to Book Management API" });
// });

// app.listen(PORT, () => {
//   console.log(`Server running on http://localhost:${PORT}`);
// });

const express = require("express");
const { readBooks, writeBooks } = require("./services/bookService");
const EventEmitter = require("events");

const app = express();
const PORT = 3000;
app.use(express.json());

const eventEmitter = new EventEmitter();

// Event logs
eventEmitter.on("bookAdded", (book) => console.log(" Book Added:", book));
eventEmitter.on("bookUpdated", (book) => console.log(" Book Updated:", book));
eventEmitter.on("bookDeleted", (id) => console.log(" Book Deleted:", id));

// Root
app.get("/", (req, res) => {
  res.json({ message: "Welcome to Book Management API" });
});

// GET all books
app.get("/books", async (req, res) => {
  const books = await readBooks();
  res.json(books);
});

// GET book by id
app.get("/books/:id", async (req, res) => {
  const books = await readBooks();
  const book = books.find((b) => b.id == req.params.id);
  book ? res.json(book) : res.status(404).json({ error: "Book not found" });
});

// POST new book
app.post("/books", async (req, res) => {
  const { title, author } = req.body;
  if (!title || !author)
    return res.status(400).json({ error: "Title & author required" });

  const books = await readBooks();
  const newBook = { id: Date.now(), title, author };
  books.push(newBook);
  await writeBooks(books);

  eventEmitter.emit("bookAdded", newBook);
  res.status(201).json(newBook);
});

// PUT update book
app.put("/books/:id", async (req, res) => {
  const { title, author } = req.body;
  const books = await readBooks();
  const index = books.findIndex((b) => b.id == req.params.id);

  if (index === -1) return res.status(404).json({ error: "Book not found" });

  books[index] = { ...books[index], title, author };
  await writeBooks(books);

  eventEmitter.emit("bookUpdated", books[index]);
  res.json(books[index]);
});

// DELETE book
app.delete("/books/:id", async (req, res) => {
  const books = await readBooks();
  const newBooks = books.filter((b) => b.id != req.params.id);

  if (books.length === newBooks.length)
    return res.status(404).json({ error: "Book not found" });

  await writeBooks(newBooks);
  eventEmitter.emit("bookDeleted", req.params.id);
  res.json({ message: "Book deleted" });
});

app.listen(PORT, () =>
  console.log(`🚀 Server running on http://localhost:${PORT}`)
);
