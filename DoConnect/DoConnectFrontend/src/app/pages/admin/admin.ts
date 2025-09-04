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
  pq: any[] = [];
  pa: any[] = [];
  async ngOnInit() {
    await this.refresh();
  }
  async refresh() {
    this.pq = await AdminService.pendingQuestions();
    this.pa = await AdminService.pendingAnswers();
  }
  async apq(id: number) {
    await AdminService.approveQuestion(id);
    await this.refresh();
  }
  async rjq(id: number) {
    await AdminService.rejectQuestion(id);
    await this.refresh();
  }
  async apa(id: number) {
    await AdminService.approveAnswer(id);
    await this.refresh();
  }
  async rja(id: number) {
    await AdminService.rejectAnswer(id);
    await this.refresh();
  }
}
