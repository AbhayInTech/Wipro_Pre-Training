import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { environment } from '../../environments/environment';

type TokenPayload = { name: string; role: string; sub: string; exp: number };

export class AuthService {
  tokenKey = 'dc_token';

  async register(username: string, password: string, role: 'User' | 'Admin' = 'User') {
    const res = await axios.post(`${environment.api}/auth/register`, { username, password, role });
    localStorage.setItem(this.tokenKey, res.data.token);
    return res.data;
  }

  async login(username: string, password: string) {
    const res = await axios.post(`${environment.api}/auth/login`, { username, password });
    localStorage.setItem(this.tokenKey, res.data.token);
    return res.data;
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }

  get token() {
    return localStorage.getItem(this.tokenKey);
  }

  get isLoggedIn() {
    return !!this.token;
  }

  get role() {
    const t = this.token;
    if (!t) return null;
    const payload = jwtDecode<TokenPayload>(t);
    return payload.role || null;
  }

  get authHeader() {
    const t = this.token;
    return t ? { Authorization: `Bearer ${t}` } : {};
  }
}
export const authService = new AuthService();
