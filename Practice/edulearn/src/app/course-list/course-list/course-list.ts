import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Course } from '../../models/course';
import { NgFor, NgIf } from '@angular/common';
@Component({
  selector: 'app-course-list',
  imports: [NgFor],
  templateUrl: './course-list.html',
  styleUrls: ['./course-list.css'],
})
export class CourseList {
  @Input() courses: Course[] = [];
  @Output() selectCourse = new EventEmitter<Course>();

  onViewDetails(course: Course) {
    // Event Binding: emit to parent when a course is selected
    this.selectCourse.emit(course);
  }
}
