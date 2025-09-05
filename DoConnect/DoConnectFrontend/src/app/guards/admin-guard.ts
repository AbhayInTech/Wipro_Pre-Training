import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { authService } from '../services/auth-service';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    if (!authService.isLoggedIn || authService.role !== 'Admin') {
      authService.logout();
      this.router.navigate(['/login']); // redirect to home if not admin
      return false;
    }
    return true; // allow admin navigation
  }
}
