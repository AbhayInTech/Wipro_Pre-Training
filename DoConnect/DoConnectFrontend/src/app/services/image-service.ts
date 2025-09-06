import axios from 'axios';
import { environment } from '../../environments/environment';

export const ImageService = {
  async fetchImagesByQuestion(questionId: string) {
    const url = `${environment.api}/images/by-question-or-answer?questionId=${questionId}`;
    const response = await axios.get(url);
    return response.data;
  },

  async fetchImagesByAnswer(answerId: string) {
    const url = `${environment.api}/images/by-question-or-answer?answerId=${answerId}`;
    const response = await axios.get(url);
    return response.data;
  },

  getImageUrlById(imageId: string) {
    return `${environment.api}/images/by-imageid/${imageId}`;
  },
};
