import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { environment } from '../../environments/environment';

const Role = `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`;

type TokenPayload = {
  name: string;
  [Role]: string;
  sub: string;
  exp: number;
};

export class AuthService {
  tokenKey = 'dc_token';

  async register(username: string, password: string, role: 'User' | 'Admin' = 'User') {
    const res = await axios.post(`${environment.api}/auth/register`, { username, password, role });
    sessionStorage.setItem(this.tokenKey, res.data.token);
    return res.data;
  }

  async login(username: string, password: string) {
    const res = await axios.post(`${environment.api}/auth/login`, { username, password });
    sessionStorage.setItem(this.tokenKey, res.data.token);
    return res.data;
  }

  logout() {
    sessionStorage.removeItem(this.tokenKey);
  }

  get token() {
    return sessionStorage.getItem(this.tokenKey);
  }

  get isLoggedIn() {
    return !!this.token;
  }

  get role() {
    const t = this.token;
    if (!t) return null;
    const payload = jwtDecode<TokenPayload>(t);
    // console.log(payload);
    // console.log(payload[Role]);
    return payload[Role] || null;
  }

  get authHeader() {
    const t = this.token;
    return t ? { Authorization: `Bearer ${t}` } : {};
  }
}
export const authService = new AuthService();
