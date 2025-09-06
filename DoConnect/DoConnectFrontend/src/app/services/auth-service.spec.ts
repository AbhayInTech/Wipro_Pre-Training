import { AuthService } from './auth-service';

describe('AuthService', () => {
  let authService: AuthService;

  beforeEach(() => {
    authService = new AuthService();
  });

  it('should have isLoggedIn property', () => {
    expect('isLoggedIn' in authService).toBeTrue();
  });

  it('should have role property', () => {
    expect('role' in authService).toBeTrue();
  });

  it('should have token property', () => {
    expect('token' in authService).toBeTrue();
  });

  it('should have authHeader property', () => {
    expect('authHeader' in authService).toBeTrue();
  });

  it('should have logout method', () => {
    expect(typeof authService.logout).toBe('function');
  });
});
