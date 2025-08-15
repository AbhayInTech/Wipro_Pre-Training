import { Component, signal } from '@angular/core';
import { Course } from './models/course';
import { CourseList } from './course-list/course-list/course-list';
import { CourseDetail } from './course-detail/course-detail/course-detail';
import { NgFor } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [CourseList, CourseDetail, NgFor],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  title = 'EduLearn Courses';

  courses: Course[] = [
    {
      id: 1,
      title: 'Angular Basics',
      description: 'Intro to components, templates, and data binding.',
      author: 'Jane Doe',
      durationMins: 90,
    },
    {
      id: 2,
      title: 'TypeScript Essentials',
      description: 'Types, interfaces, and classes for Angular devs.',
      author: 'John Smith',
      durationMins: 75,
    },
    {
      id: 3,
      title: 'RxJS in Angular',
      description: 'Observables and operators in real apps.',
      author: 'Alex Kim',
      durationMins: 120,
    },
  ];

  selectedCourse: Course | null = this.courses[0];

  // Event handler: receives chosen course from CourseListComponent
  handleSelectCourse(course: Course) {
    this.selectedCourse = course;
  }
}
