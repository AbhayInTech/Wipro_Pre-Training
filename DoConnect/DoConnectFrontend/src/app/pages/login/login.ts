import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { authService } from '../../services/auth-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  username = '';
  password = '';
  msg = '';
  constructor(private router: Router) {}
  async submit() {
    try {
      await authService.login(this.username, this.password);
      this.router.navigateByUrl('/');
    } catch (e: any) {
      this.msg = e?.response?.data || 'Login failed';
    }
  }
}
