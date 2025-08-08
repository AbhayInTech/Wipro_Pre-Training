import express from "express";

// Create an instance of express
const app = express();
// Define a simple route
app.get("/", (_, res) => {
  res.send("Hello, World!");
});
// Start the server on port 3000
const PORT = 5000;
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
