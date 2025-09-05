import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { AdminGuard } from './admin-guard';

import { Router } from '@angular/router';

describe('AdminGuard', () => {
  let guard: AdminGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        AdminGuard,
        { provide: Router, useValue: { navigate: jasmine.createSpy('navigate') } },
      ],
    });
    const router = TestBed.inject(Router);
    guard = new AdminGuard(router);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
