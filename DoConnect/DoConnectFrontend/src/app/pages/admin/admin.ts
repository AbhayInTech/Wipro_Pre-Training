import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  imports: [CommonModule],
  templateUrl: './admin.html',
  styleUrl: './admin.css',
})
export class Admin implements OnInit {
  pq: any = [];
  pa: any = [];
  rq: any = [];
  ra: any = [];
  aq: any = [];
  aa: any = [];
  users: any = [];
  totalUsers: number = 0;
  totalQuestions: number = 0;
  async ngOnInit() {
    await this.refresh();
  }
  async refresh() {
    this.pq = await AdminService.pendingQuestions();
    this.pa = await AdminService.pendingAnswers();
    this.rq = await AdminService.rejectedQuestions();
    this.ra = await AdminService.rejectedAnswers();
    this.aq = await AdminService.approvedQuestions();
    this.aa = await AdminService.approvedAnswers();
    this.totalUsers = await AdminService.getTotalUsers();
    this.totalQuestions = await AdminService.getTotalQuestions();
    this.users = await AdminService.getUsers();
  }
  async apq(id: string) {
    await AdminService.approveQuestion(id);
    await this.refresh();
  }
  async rjq(id: string) {
    await AdminService.rejectQuestion(id);
    await this.refresh();
  }
  async apa(id: string) {
    await AdminService.approveAnswer(id);
    await this.refresh();
  }
  async rja(id: string) {
    await AdminService.rejectAnswer(id);
    await this.refresh();
  }
  viewAllQuestions() {
    // Navigate to all questions page
    window.location.href = '/questions';
  }
  viewAllAnswers() {
    // Placeholder: Navigate to all answers page or implement logic
    window.location.href = '/questions';
  }
  async deleteUser(id: string) {
    if (confirm('Are you sure you want to delete this user?')) {
      await AdminService.deleteUser(id);
      await this.refresh();
    }
  }
  editUser(id: string) {
    alert('Edit user functionality not implemented yet.');
  }
  manageUsers() {
    // Placeholder: Navigate to user management page or implement logic
    console.log('Manage users');
  }
}
