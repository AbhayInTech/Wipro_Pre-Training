// first file for demo purpose in typescript
var Greeter = /** @class */ (function () {
    function Greeter(name) {
        this.name = name;
    }
    Greeter.prototype.greet = function () {
        return "Hello, ".concat(this.name, "!");
    };
    return Greeter;
}());
var names = "Abhay";
var greeter = new Greeter(names);
console.log(greeter.greet());
