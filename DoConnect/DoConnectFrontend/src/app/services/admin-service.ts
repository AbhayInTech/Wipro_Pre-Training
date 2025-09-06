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
  async rejectedQuestions() {
    return (
      await axios.get(`${environment.api}/admin/rejected/questions`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async rejectedAnswers() {
    return (
      await axios.get(`${environment.api}/admin/rejected/answers`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async approvedQuestions() {
    return (
      await axios.get(`${environment.api}/admin/approved/questions`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async approvedAnswers() {
    return (
      await axios.get(`${environment.api}/admin/approved/answers`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async approveQuestion(id: string) {
    return (
      await axios.post(
        `${environment.api}/admin/approve/question/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async rejectQuestion(id: string) {
    return (
      await axios.post(
        `${environment.api}/admin/reject/question/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async approveAnswer(id: string) {
    return (
      await axios.post(
        `${environment.api}/admin/approve/answer/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async rejectAnswer(id: string) {
    return (
      await axios.post(
        `${environment.api}/admin/reject/answer/${id}`,
        {},
        { headers: authService.authHeader }
      )
    ).data;
  },
  async getTotalUsers() {
    return (
      await axios.get(`${environment.api}/admin/total/users`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async getTotalQuestions() {
    return (
      await axios.get(`${environment.api}/admin/total/questions`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async getUsers() {
    return (
      await axios.get(`${environment.api}/admin/users`, {
        headers: authService.authHeader,
      })
    ).data;
  },
  async deleteUser(id: string) {
    return (
      await axios.delete(`${environment.api}/admin/user/${id}`, {
        headers: authService.authHeader,
      })
    ).data;
  },
};
