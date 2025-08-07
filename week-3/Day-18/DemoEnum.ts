// step1: Declaring an enum which will work as a type with fix values
enum Direction {
  Up, //0
  Down, //1
  Left, //2
  Right, //3
}
// step2: Using the enum
function move(direction: Direction) {
  console.log(`Moving in direction: ${Direction[direction]}`);
  // here Direction[direction] converts the enum value to its string representation
}

move(Direction.Up); // Output: Moving in direction: Up
move(Direction.Down); // Output: Moving in direction: Down

let randomValue: any;
// Assigning a value from the enum to a variable
randomValue = "Hello";
// we will use any type to allow different types of values, when we don't know the type in advance
console.log(randomValue); // Output: Hello
randomValue = 42;
console.log(randomValue); // Output: 42
randomValue = { name: "Abhay" };
console.log(randomValue); // Output: { name: "Abhay" }

let user: [string, number];
user = ["Rana", 25]; // Tuple type with string and number
console.log(user); // Output: [ 'Abhay', 25 ]
console.log(`User Name: ${user[0]}, Age: ${user[1]}`); // Output: User Name: Rana, Age: 25
