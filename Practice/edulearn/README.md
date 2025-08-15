EduLearn Course Management – Angular SPA
Steps to Install Dependencies and Run the App

Install Node.js and Angular CLI (if not already installed)

Download Node.js LTS from https://nodejs.org

Install Angular CLI globally:

npm install -g @angular/cli

Clone or Create Project Folder

If you already have the project files, navigate to the folder:

cd edulearn

If creating a fresh app:

ng new edulearn --routing=false --style=css
cd edulearn

Copy the Source Files

Replace src/ contents with the provided files (app.module.ts, app.component.\*, course-list, course-detail, and models folder).

Install Dependencies

npm install

Run the App

ng serve -o

The app will open automatically in your default browser at http://localhost:4200.

Data Binding Usage in This App

1. Property Binding

Where:

<app-course-detail [course]="selectedCourse"></app-course-detail>

How: Passes the selectedCourse object from AppComponent to CourseDetailComponent via the @Input() property course.

2. Event Binding

Where:

<button type="button" (click)="onViewDetails(c)">View Details</button>

How: The CourseListComponent emits a selectCourse event when a course is selected.
In AppComponent:

<app-course-list (selectCourse)="handleSelectCourse($event)"></app-course-list>

This triggers handleSelectCourse() to update the selected course.

3. Two-Way Binding

Where:

<input [(ngModel)]="course.title" />

How: In CourseDetailComponent, fields like title, author, and description are bound using [(ngModel)]. This allows live editing of course details that immediately reflects in both the detail panel and the course list, because they reference the same object.
