import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionService } from '../../services/question-service';
import { AnswerService } from '../../services/answer-service';
import { AdminService } from '../../services/admin-service';

@Component({
  selector: 'app-manage-user',
  imports: [CommonModule],
  templateUrl: './manage-user.html',
  styleUrl: './manage-user.css',
})
export class ManageUser implements OnInit {
  questions: any[] = [];
  users: any[] = [];

  constructor() {}

  async ngOnInit() {
    await this.loadData();
  }

  async loadData() {
    try {
      // Fetch questions with answers and user info in one API call
      const data = await AdminService.getQuestionsWithAnswersAndUsers();
      this.questions = data.$values || data;
    } catch (error) {
      console.error('Error loading data:', error);
    }
  }

  async approveQuestion(questionId: string) {
    try {
      await AdminService.approveQuestion(questionId);
      await this.loadData(); // Reload data to reflect changes
    } catch (error) {
      console.error('Error approving question:', error);
    }
  }

  async rejectQuestion(questionId: string) {
    try {
      await AdminService.rejectQuestion(questionId);
      await this.loadData(); // Reload data to reflect changes
    } catch (error) {
      console.error('Error rejecting question:', error);
    }
  }

  async approveAnswer(answerId: string) {
    try {
      await AdminService.approveAnswer(answerId);
      await this.loadData(); // Reload data to reflect changes
    } catch (error) {
      console.error('Error approving answer:', error);
    }
  }

  async rejectAnswer(answerId: string) {
    try {
      await AdminService.rejectAnswer(answerId);
      await this.loadData(); // Reload data to reflect changes
    } catch (error) {
      console.error('Error rejecting answer:', error);
    }
  }

  async deleteQuestion(questionId: string) {
    if (
      confirm(
        'Are you sure you want to delete this question? This will also delete all associated answers and images.'
      )
    ) {
      try {
        // Backend handles cascading deletes for answers and images
        await AdminService.deleteQuestion(questionId);
        await this.loadData(); // Reload data to reflect changes
      } catch (error) {
        console.error('Error deleting question:', error);
      }
    }
  }
}
