import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { authService } from '../../services/auth-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  username = '';
  password = '';
  role: 'User' | 'Admin' = 'User';
  msg = '';
  constructor(private router: Router) {}
  async submit() {
    try {
      console.log(this.username, this.password);
      await authService.register(this.username, this.password, this.role);
      this.router.navigateByUrl('/');
    } catch (e: any) {
      this.msg = e?.response?.data || 'Register failed';
    }
  }
}
