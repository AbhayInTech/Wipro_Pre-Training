import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { authService } from '../services/auth-service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    if (!authService.isLoggedIn) {
      this.router.navigate(['/login']); // redirect if not logged in
      return false;
    }
    return true; // allow navigation
  }
}
