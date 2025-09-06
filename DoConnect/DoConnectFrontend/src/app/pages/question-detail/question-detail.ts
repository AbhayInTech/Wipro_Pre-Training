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
  id!: string;
  q: any;
  answers: any[] = [];
  text = '';
  msg = '';
  image: any;
  constructor(private route: ActivatedRoute) {}
  async ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || '0';
    this.q = await QuestionService.get(this.id);
    const answersData = await AnswerService.byQuestion(this.id);
    this.answers = answersData.$values || answersData;

    // Fetch images for the question and answers
    try {
      const response = await fetch(
        `http://localhost:5035/api/images/by-question-or-answer?questionId=${this.id}`
      );
      if (response.ok) {
        const images = await response.json();
        const allImages = images.$values || images;
        // Assign images to question
        this.q.Images = allImages.filter((img: any) => !img.answerId);
        // Assign images to answers
        this.answers.forEach((a: any) => {
          a.images = allImages.filter((img: any) => img.answerId === a.AnswerId);
        });
      }
    } catch (error) {
      console.error('Failed to load images', error);
    }
  }
  file: File | null = null;

  onFileSelected(event: any) {
    this.file = event.target.files[0];
  }

  async submit() {
    try {
      await AnswerService.create(this.id, this.text, this.file);
      this.msg = 'Answer submitted for approval';
      this.text = '';
      this.file = null;
    } catch (e: any) {
      this.msg = e?.response?.data || 'Failed';
    }
  }
}
