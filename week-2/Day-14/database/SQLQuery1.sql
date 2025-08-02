-- Create Database
-- Create Database CollegeRecords;
-- Use CollegeRecords;


-- Create Students table
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50),
    email VARCHAR(50),
    major VARCHAR(50),
    enrollment_year INT
);

 

-- Create Courses table
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(50),
    credit_hours INT,
    department VARCHAR(50)
);

 

-- Create StudentCourses table for enrollment
CREATE TABLE StudentCourses (
    enrollment_id INT PRIMARY KEY,
    student_id INT,
    course_id INT,
    semester VARCHAR(20),
    grade CHAR(2),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

-- Insert sample data
INSERT INTO Students VALUES 
(1, 'John Doe', 'john@example.com', 'Computer Science', 2020),
(2, 'Jane Smith', 'jane@example.com', 'Mathematics', 2021),
(3, 'Mike Johnson', 'mike@example.com', 'Physics', 2020);

 

INSERT INTO Courses VALUES
(101, 'Database Systems', 3, 'CS'),
(102, 'Calculus II', 4, 'MATH'),
(103, 'Quantum Physics', 4, 'PHYSICS');

 

INSERT INTO StudentCourses VALUES
(1, 1, 101, 'Fall 2023', 'A'),
(2, 1, 102, 'Spring 2024', 'B'),
(3, 2, 102, 'Fall 2023', 'A'),
(4, 3, 103, 'Spring 2024', 'B+');


-- Student Course Details
CREATE VIEW StudentCourseDetails AS
SELECT 
    s.student_id,
    s.student_name,
    s.major,
    c.course_name,
    sc.semester,
    sc.grade
FROM 
    Students s
 INNER JOIN 
    StudentCourses sc ON s.student_id = sc.student_id
INNER JOIN 
    Courses c ON sc.course_id = c.course_id;

SELECT * FROM StudentCourseDetails;


-- Students that are enrolled in Fall 2023
CREATE VIEW Fall2023Enrollments AS
SELECT 
    s.student_id,
    s.student_name,
    c.course_name,
    sc.grade
FROM 
    Students s
JOIN 
    StudentCourses sc ON s.student_id = sc.student_id
JOIN 
    Courses c ON sc.course_id = c.course_id
WHERE 
    sc.semester = 'Fall 2023';

SELECT * FROM Fall2023Enrollments;
