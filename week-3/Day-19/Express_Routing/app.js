const express = require("express");
const app = express();
const port = 3000;

app.use(express.json());

// handle GET request
app.get("/", (req, res) => {
  res.send("Welcome to Express Routing!");
});
// just use / to access this route

// Handle post request
app.post("/data", (req, res) => {
  res.json({
    message: "Data received successfully",
    data: req.body,
  });
});

// just use /data to access this route

// Handle put request
app.put("/update", (req, res) => {
  res.json({
    message: "Data updated successfully",
    data: req.body,
  });
});

// Handle DELETE request
app.delete("/delete", (req, res) => {
  res.json({
    message: "Data deleted successfully",
  });
});

// dynamic routing
app.get("/user/:id", (req, res) => {
  const userId = req.params.id;
  res.send(`User ID is: ${userId}`);
});

app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});
