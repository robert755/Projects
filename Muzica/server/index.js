var api = require("./src/api.js").app;
var users = require("./src/users.json");

api.get("/", function (request, response) {
  response.json("NodeJS REST API");
});

// http://localhost:3000/

api.get("/users", function (request, response) {
  response.json(users);
});

api.post("/createUser",function(request,response){
  const album=request.body.album.trim();
  const artist=request.body.artist.trim();
  const price=request.body.price.trim();
  users.push({album:album,artist:artist,price:price});
  response.json(users);
})

api.delete("/deleteUser",function(request,response){
  const index=request.query.index;
  users.splice(index,1);
  response.json(users);
})


// http://localhost:3000/

api.listen(3000, function () {
  console.log("Server running @ localhost:3000");
});
