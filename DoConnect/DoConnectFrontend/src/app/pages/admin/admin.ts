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
  async ngOnInit() {
    await this.refresh();
  }
  async refresh() {
    this.pq = await AdminService.pendingQuestions();
    // console.log(this.pq);
    this.pa = await AdminService.pendingAnswers();
    // console.log(this.pa);
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
}
