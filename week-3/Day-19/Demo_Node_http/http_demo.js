// http_demo.js

const http = require("http");

const server = http.createServer((req, res) => {
  res.writeHead(200, { "Content-Type": "text/plain" });

  res.end("Hello World from HTTP Server!");
  //sends the responsse to client and ends the request response cycle
});

server.listen(3000, () => {
  console.log("Server running at http://localhost:3000/");
});
