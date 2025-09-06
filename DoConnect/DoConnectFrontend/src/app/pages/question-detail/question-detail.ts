import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionService } from '../../services/question-service';
import { AnswerService } from '../../services/answer-service';
import { ImageService } from '../../services/image-service';
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
      // console.log(this.q);
      // console.log(this.q.imageIDs);

      // Clear previous images if any
      this.q.Images = [];
      for (const answer of this.answers) {
        answer.images = [];
      }

      // For question, get ImageIDs string and map to image URLs
      if (this.q.imageIDs) {
        let questionImageIDs: string[];
        if (this.q.imageIDs.includes(',')) {
          // console.log('split');
          questionImageIDs = this.q.imageIDs.split(',');
        } else {
          // console.log('non-split');
          questionImageIDs = [this.q.imageIDs];
          // console.log(questionImageIDs);
        }
        this.q.Images = questionImageIDs.map((id: string) => {
          const url = ImageService.getImageUrlById(id);
          // console.log('Question image URL:', url);
          return {
            imageId: id,
            url,
          };
        });
      }

      // For each answer, get ImageIDs string and map to image URLs
      for (const answer of this.answers) {
        // console.log(this.answers);
        if (answer.imageIDs) {
          // console.log(answer.imageIDs);
          let answerImageIDs: string[];
          if (answer.imageIDs.includes(',')) {
            // console.log('split');
            answerImageIDs = answer.imageIDs.split(',');
          } else {
            // console.log('non-split');
            answerImageIDs = [answer.imageIDs];
          }
          answer.images = answerImageIDs.map((id: string) => {
            const url = ImageService.getImageUrlById(id);
            // console.log('Answer image URL:', url);
            return {
              imageId: id,
              url,
            };
          });
        }
      }
    } catch (error) {
      console.error('Failed to load images', error);
    }
  }
  files: File[] = [];

  onFileSelected(event: any) {
    this.files = Array.from(event.target.files);
  }

  async submit() {
    try {
      await AnswerService.create(this.id, this.text, this.files);
      this.msg = 'Answer submitted for approval';
      this.text = '';
      this.files = [];
    } catch (e: any) {
      this.msg = e?.response?.data || 'Failed';
    }
  }
}
