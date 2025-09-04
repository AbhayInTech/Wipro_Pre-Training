import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionService } from '../../services/question-service';
import { AnswerService } from '../../services/answer-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-question-detail',
  imports: [FormsModule, CommonModule],
  templateUrl: './question-detail.html',
  styleUrl: './question-detail.css',
})
export class QuestionDetail implements OnInit {
  id!: number;
  q: any;
  answers: any[] = [];
  text = '';
  msg = '';
  constructor(private route: ActivatedRoute) {}
  async ngOnInit() {
    this.id = +(this.route.snapshot.paramMap.get('id') || 0);
    this.q = await QuestionService.get(this.id);
    this.answers = await AnswerService.byQuestion(this.id);
  }
  async submit() {
    try {
      await AnswerService.create(this.id, this.text);
      this.msg = 'Answer submitted for approval';
      this.text = '';
    } catch (e: any) {
      this.msg = e?.response?.data || 'Failed';
    }
  }
}
