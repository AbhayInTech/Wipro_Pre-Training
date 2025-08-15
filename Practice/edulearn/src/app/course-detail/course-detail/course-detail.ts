import { Component, Input } from '@angular/core';
import { Course } from '../../models/course';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './course-detail.html',
  styleUrls: ['./course-detail.css'],
})
export class CourseDetail {
  // Property Binding: parent passes selected course into this input
  @Input() course: Course | null = null;
}
