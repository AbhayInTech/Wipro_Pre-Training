import axios from 'axios';
import { environment } from '../../environments/environment';
import { authService } from './auth-service';

export const QuestionService = {
  async list(includePending = false) {
    const url = `${environment.api}/questions?includePending=${includePending}`;
    return (await axios.get(url)).data;
  },
  async get(id: string) {
    return (await axios.get(`${environment.api}/questions/${id}`)).data;
  },
  async search(q: string) {
    return (await axios.get(`${environment.api}/questions/search`, { params: { q } })).data;
  },
  async create(title: string, text: string, files: File[]) {
    console.log(title, text, files);
    const formData = new FormData();
    formData.append('title', title);
    formData.append('text', text);
    if (files && files.length > 0) {
      for (const file of files) {
        formData.append('images', file);
      }
    }
    return (
      await axios.post(`${environment.api}/questions`, formData, {
        headers: { ...authService.authHeader, 'Content-Type': 'multipart/form-data' },
      })
    ).data;
  },
};
