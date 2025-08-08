var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
// Enum
var Department;
(function (Department) {
    Department["Science"] = "Science";
    Department["Commerce"] = "Commerce";
    Department["Arts"] = "Arts";
})(Department || (Department = {}));
// Decorator with generic typing (fixed)
function LogCreation(constructor) {
    console.log(`Student class created: ${constructor.name}`);
}
// Class with tuple and extended features
let Student = class Student {
    constructor() {
        // Fixed: Map now works with ES2015+
        this.studentMap = new Map();
        console.log("Student System Initialized");
    }
    addStudent(student) {
        const { id, name, age, department } = student;
        this.studentMap.set(id, [name, age, department]);
        console.log(`Added Student: ${name}, ID: ${id}`);
    }
    getStudentById(id) {
        return this.studentMap.get(id);
    }
    updateStudent(id, updatedDetails) {
        var _a, _b, _c;
        const existing = this.studentMap.get(id);
        if (!existing) {
            console.log(`Student with ID ${id} not found.`);
            return;
        }
        const [name, age, department] = existing;
        this.studentMap.set(id, [
            (_a = updatedDetails.name) !== null && _a !== void 0 ? _a : name,
            (_b = updatedDetails.age) !== null && _b !== void 0 ? _b : age,
            (_c = updatedDetails.department) !== null && _c !== void 0 ? _c : department,
        ]);
        console.log(`Updated Student ID: ${id}`);
    }
    deleteStudent(id) {
        if (this.studentMap.delete(id)) {
            console.log(`Deleted Student ID: ${id}`);
        }
        else {
            console.log(`Student with ID ${id} not found.`);
        }
    }
    filterByDepartment(dept) {
        console.log(`Students in ${dept} Department:`);
        for (const [id, [name, age, department]] of this.studentMap.entries()) {
            if (department === dept) {
                console.log(`ID: ${id}, Name: ${name}, Age: ${age}`);
            }
        }
    }
    printAllStudents() {
        console.log("All Students:");
        for (const [id, [name, age, dept]] of this.studentMap.entries()) {
            console.log(`ID: ${id}, Name: ${name}, Age: ${age}, Dept: ${dept}`);
        }
    }
};
Student = __decorate([
    LogCreation
], Student);
// Usage
const s = new Student();
s.addStudent({ id: 1, name: "Raj", age: 20, department: Department.Science });
s.addStudent({ id: 2, name: "Simran", age: 21, department: Department.Arts });
s.printAllStudents();
s.updateStudent(1, { age: 22 });
s.getStudentById(1); // Optional: use this result or log it
s.filterByDepartment(Department.Science);
s.deleteStudent(2);
s.printAllStudents();
