// import { Injectable } from '@angular/core';
import axios from 'axios';
import { environment } from '../../environments/environment';
import { authService } from './auth-service';

// @Injectable({
//   providedIn: 'root'
// })

export const AnswerService = {
  async byQuestion(questionId: number) {
    return (await axios.get(`${environment.api}/answers/by-question/${questionId}`)).data;
  },
  async create(questionId: number, text: string) {
    return (
      await axios.post(
        `${environment.api}/answers`,
        { questionId, text },
        { headers: authService.authHeader }
      )
    ).data;
  },
};
