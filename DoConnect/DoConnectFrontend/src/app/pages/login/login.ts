import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { authService } from '../../services/auth-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  username = '';
  password = '';
  role = '';
  msg = '';
  response: any;
  constructor(private router: Router) {}
  async submit() {
    try {
      // console.log(this.username, this.password);
      // login function returns response object so we have to store it in a variable

      this.response = await authService.login(this.username, this.password);
      // console.log(this.response);
      if (this.response.role === 'User') {
        this.router.navigateByUrl('/questions');
      }
      if (this.response.role === 'Admin') {
        this.router.navigateByUrl('/admin');
      }
    } catch (e: any) {
      this.msg = e?.response?.data || 'Login failed';
    }
  }
}
