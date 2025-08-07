// step1: Declaring an enum which will work as a type with fix values
var Direction;
(function (Direction) {
    Direction[Direction["Up"] = 0] = "Up";
    Direction[Direction["Down"] = 1] = "Down";
    Direction[Direction["Left"] = 2] = "Left";
    Direction[Direction["Right"] = 3] = "Right";
})(Direction || (Direction = {}));
// step2: Using the enum
function move(direction) {
    console.log("Moving in direction: ".concat(Direction[direction]));
    // here Direction[direction] converts the enum value to its string representation
}
move(Direction.Up); // Output: Moving in direction: Up
move(Direction.Down); // Output: Moving in direction: Down
var randomValue;
// Assigning a value from the enum to a variable
randomValue = "Hello";
// we will use any type to allow different types of values, when we don't know the type in advance
console.log(randomValue); // Output: Hello
randomValue = 42;
console.log(randomValue); // Output: 42
randomValue = { name: "Abhay" };
console.log(randomValue); // Output: { name: "Abhay" }
var user;
user = ["Rana", 25]; // Tuple type with string and number
console.log(user); // Output: [ 'Abhay', 25 ]
console.log("User Name: ".concat(user[0], ", Age: ").concat(user[1])); // Output: User Name: Rana, Age: 25
