const fs = require("fs").promises;
const path = require("path");

const filePath = path.join(__dirname, "../data/books.json");

async function readBooks() {
  try {
    const data = await fs.readFile(filePath, "utf8");
    return JSON.parse(data);
  } catch (err) {
    return [];
  }
}

async function writeBooks(books) {
  try {
    await fs.writeFile(filePath, JSON.stringify(books, null, 2));
  } catch (err) {
    console.error("Error writing file:", err);
  }
}

module.exports = { readBooks, writeBooks };
