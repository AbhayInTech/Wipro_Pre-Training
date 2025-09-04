import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { QuestionService } from '../../services/question-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ask',
  imports: [FormsModule, CommonModule],
  templateUrl: './ask.html',
  styleUrl: './ask.css',
})
export class Ask {
  title = '';
  text = '';
  msg = '';
  constructor(private router: Router) {}
  async submit() {
    try {
      await QuestionService.create(this.title, this.text);
      this.router.navigateByUrl('/');
    } catch (e: any) {
      this.msg = e?.response?.data || 'Failed';
    }
  }
}
