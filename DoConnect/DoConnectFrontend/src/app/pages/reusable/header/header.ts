import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { authService } from '../../../services/auth-service';
import { notificationService } from '../../../services/notification-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [RouterLink, CommonModule],
  templateUrl: './header.html',
  styleUrl: './header.css',
  encapsulation: ViewEncapsulation.None,
})
export class Header implements OnInit {
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

  get hasNewNotifications() {
    return notificationService.hasNewNotifications;
  }

  constructor(private router: Router) {}

  async ngOnInit() {
    if (this.role === 'Admin') {
      await notificationService.joinGroup('Admin');
      notificationService.onNotificationReceived((user, message) => {
        notificationService.hasNewNotifications = true;
      });
    }
  }

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
