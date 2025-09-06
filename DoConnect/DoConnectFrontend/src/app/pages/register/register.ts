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
  Confirm_password = '';
  usernameError = '';
  passwordError = '';
  confirmError = '';
  isFormValid = false;

  constructor(private router: Router) {}

  validate() {
    this.msg = ''; // Clear previous messages
    this.usernameError = this.username.length < 3 ? 'Username must be at least 3 characters' : '';
    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])/;
    this.passwordError = !passwordRegex.test(this.password)
      ? 'Password must contain at least one lowercase letter, one uppercase letter, one number, and one symbol'
      : '';
    this.confirmError = this.password !== this.Confirm_password ? 'Passwords do not match' : '';
    this.isFormValid =
      !this.usernameError &&
      !this.passwordError &&
      !this.confirmError &&
      !!this.username &&
      !!this.password &&
      !!this.Confirm_password;
  }

  async submit() {
    this.validate();
    if (!this.isFormValid) {
      this.msg = 'Please correct the errors before submitting';
      return;
    }
    try {
      // console.log(this.username, this.password);
      await authService.register(this.username, this.password, this.role);
      this.router.navigateByUrl('/');
    } catch (e: any) {
      this.msg = e?.response?.data || 'Register failed';
    }
  }
}
