import { QuestionService } from './question-service';

describe('QuestionService', () => {
  it('should have list method', () => {
    expect(typeof QuestionService.list).toBe('function');
  });

  it('should have get method', () => {
    expect(typeof QuestionService.get).toBe('function');
  });

  it('should have search method', () => {
    expect(typeof QuestionService.search).toBe('function');
  });

  it('should have create method', () => {
    expect(typeof QuestionService.create).toBe('function');
  });
});
