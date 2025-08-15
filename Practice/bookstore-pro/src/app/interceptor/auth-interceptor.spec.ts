import { AuthInterceptor } from './auth-interceptor';
import { HttpRequest, HttpHandler } from '@angular/common/http';

describe('AuthInterceptor', () => {
  it('should add Authorization header', () => {
    const interceptor = new AuthInterceptor();
    const req = new HttpRequest('GET', '/test');
    const next: HttpHandler = {
      handle: (request) => {
        expect(request.headers.has('Authorization')).toBeTrue();
        return {
          subscribe: () => {},
        } as any;
      },
    };
    interceptor.intercept(req, next);
  });
});
