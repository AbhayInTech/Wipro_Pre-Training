// first file for demo purpose in typescript
class Greeter {
  name: string;
  constructor(name: string) {
    this.name = name;
  }
  greet(): string {
    return `Hello, ${this.name}!`;
  }
}

let names: string = "Abhay";
let greeter = new Greeter(names);
console.log(greeter.greet());
