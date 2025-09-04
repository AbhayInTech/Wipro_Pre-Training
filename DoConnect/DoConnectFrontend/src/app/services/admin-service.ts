import axios from 'axios';
import { environment } from '../../environments/environment';
import { authService } from './auth-service';

export const AdminService = {
  async pendingQuestions() {
    return (
      await axios.get(`${environment.api}/admin/pending/questions`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async pendingAnswers() {
    return (
      await axios.get(`${environment.api}/admin/pending/answers`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async approveQuestion(id: number) {
    return (
      await axios.post(
        `${environment.api}/admin/approve/question/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async rejectQuestion(id: number) {
    return (
      await axios.post(
        `${environment.api}/admin/reject/question/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async approveAnswer(id: number) {
    return (
      await axios.post(
        `${environment.api}/admin/approve/answer/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async rejectAnswer(id: number) {
    return (
      await axios.post(
        `${environment.api}/admin/reject/answer/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
};
