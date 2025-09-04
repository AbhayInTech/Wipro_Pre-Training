import axios from 'axios';
import { environment } from '../../environments/environment';
import { authService } from './auth-service';

export const QuestionService = {
  async list(includePending = false) {
    const url = `${environment.api}/questions?includePending=${includePending}`;
    return (await axios.get(url)).data;
  },
  async get(id: number) {
    return (await axios.get(`${environment.api}/questions/${id}`)).data;
  },
  async search(q: string) {
    return (await axios.get(`${environment.api}/questions/search`, { params: { q } })).data;
  },
  async create(title: string, text: string) {
    return (
      await axios.post(
        `${environment.api}/questions`,
        { title, text },
        { headers: authService.authHeader }
      )
    ).data;
  },
};
