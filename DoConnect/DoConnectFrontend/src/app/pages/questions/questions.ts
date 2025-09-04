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
    this.list = await QuestionService.list(this.includePending);
  }
  async search() {
    this.list = await QuestionService.search(this.q);
  }
}
