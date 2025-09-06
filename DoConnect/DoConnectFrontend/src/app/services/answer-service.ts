// import { Injectable } from '@angular/core';
import axios from 'axios';
import { environment } from '../../environments/environment';
import { authService } from './auth-service';

// @Injectable({
//   providedIn: 'root'
// })

export const AnswerService = {
  async byQuestion(questionId: string) {
    return (await axios.get(`${environment.api}/answers/by-question/${questionId}`)).data;
  },
  async create(questionId: string, text: string, file: any) {
    const formData = new FormData();
    formData.append('questionId', questionId);
    formData.append('text', text);
    if (file) {
      formData.append('images', file);
    }
    return (
      await axios.post(`${environment.api}/answers`, formData, {
        headers: { ...authService.authHeader, 'Content-Type': 'multipart/form-data' },
      })
    ).data;
  },
};
