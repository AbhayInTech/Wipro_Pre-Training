import { Component, ViewEncapsulation } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { authService } from '../../../services/auth-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [RouterLink, CommonModule],
  templateUrl: './header.html',
  styleUrl: './header.css',
  encapsulation: ViewEncapsulation.None,
})
export class Header {
  isCollapsed = true;

  get isLoggedIn() {
    return authService.isLoggedIn;
  }
  get role() {
    return authService.role;
  }
  get username() {
    const token = authService.token;
    if (!token) return null;
    return authService.role ? authService.role + ' User' : 'User';
  }

  constructor(private router: Router) {}

  toggleNavbar() {
    this.isCollapsed = !this.isCollapsed;
  }

  collapseNavbar() {
    this.isCollapsed = true;
  }

  logout() {
    authService.logout();
    this.router.navigateByUrl('/');
  }
}
