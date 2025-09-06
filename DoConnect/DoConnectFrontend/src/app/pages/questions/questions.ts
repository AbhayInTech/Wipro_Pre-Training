import { Component, OnInit } from '@angular/core';
import { QuestionService } from '../../services/question-service';
import { Router, RouterLink } from '@angular/router';
import { authService } from '../../services/auth-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-questions',
  imports: [FormsModule, RouterLink, CommonModule],
  templateUrl: './questions.html',
  styleUrl: './questions.css',
})
export class Questions implements OnInit {
  list: any[] = [];
  q = '';
  includePending = false;
  get role() {
    return authService.role;
  }
  async ngOnInit() {
    const data = await QuestionService.list(this.includePending);
    this.list = data.$values || data;
  }
  async search() {
    const data = await QuestionService.search(this.q);
    this.list = data.$values || data;
  }
}
