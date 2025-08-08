// Enum
enum Department {
  Science = "Science",
  Commerce = "Commerce",
  Arts = "Arts",
}

// Interface
interface StudentDetails {
  id: number;
  name: string;
  age: number;
  department: Department;
}

// Decorator with generic typing (fixed)
function LogCreation<T extends { new (...args: any[]): {} }>(constructor: T) {
  console.log(`Student class created: ${(constructor as Function).name}`);
}

// Class with tuple and extended features
@LogCreation
class Student {
  // Fixed: Map now works with ES2015+
  private studentMap: Map<number, [string, number, Department]> = new Map();

  constructor() {
    console.log("Student System Initialized");
  }

  addStudent(student: StudentDetails): void {
    const { id, name, age, department } = student;
    this.studentMap.set(id, [name, age, department]);
    console.log(`Added Student: ${name}, ID: ${id}`);
  }

  getStudentById(id: number): [string, number, Department] | undefined {
    return this.studentMap.get(id);
  }

  updateStudent(id: number, updatedDetails: Partial<StudentDetails>): void {
    const existing = this.studentMap.get(id);
    if (!existing) {
      console.log(`Student with ID ${id} not found.`);
      return;
    }

    const [name, age, department] = existing;
    this.studentMap.set(id, [
      updatedDetails.name ?? name,
      updatedDetails.age ?? age,
      updatedDetails.department ?? department,
    ]);
    console.log(`Updated Student ID: ${id}`);
  }

  deleteStudent(id: number): void {
    if (this.studentMap.delete(id)) {
      console.log(`Deleted Student ID: ${id}`);
    } else {
      console.log(`Student with ID ${id} not found.`);
    }
  }

  filterByDepartment(dept: Department): void {
    console.log(`Students in ${dept} Department:`);
    for (const [id, [name, age, department]] of this.studentMap.entries()) {
      if (department === dept) {
        console.log(`ID: ${id}, Name: ${name}, Age: ${age}`);
      }
    }
  }

  printAllStudents(): void {
    console.log("All Students:");
    for (const [id, [name, age, dept]] of this.studentMap.entries()) {
      console.log(`ID: ${id}, Name: ${name}, Age: ${age}, Dept: ${dept}`);
    }
  }
}

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
