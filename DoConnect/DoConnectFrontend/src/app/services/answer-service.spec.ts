import { AnswerService } from './answer-service';

describe('AnswerService', () => {
  it('should have byQuestion method', () => {
    expect(typeof AnswerService.byQuestion).toBe('function');
  });

  it('should have create method', () => {
    expect(typeof AnswerService.create).toBe('function');
  });
});
