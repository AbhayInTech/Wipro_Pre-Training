import { AdminService } from './admin-service';

describe('AdminService', () => {
  it('should have pendingQuestions method', () => {
    expect(typeof AdminService.pendingQuestions).toBe('function');
  });

  it('should have pendingAnswers method', () => {
    expect(typeof AdminService.pendingAnswers).toBe('function');
  });

  it('should have rejectedQuestions method', () => {
    expect(typeof AdminService.rejectedQuestions).toBe('function');
  });

  it('should have rejectedAnswers method', () => {
    expect(typeof AdminService.rejectedAnswers).toBe('function');
  });

  it('should have approvedQuestions method', () => {
    expect(typeof AdminService.approvedQuestions).toBe('function');
  });

  it('should have approvedAnswers method', () => {
    expect(typeof AdminService.approvedAnswers).toBe('function');
  });

  it('should have approveQuestion method', () => {
    expect(typeof AdminService.approveQuestion).toBe('function');
  });

  it('should have rejectQuestion method', () => {
    expect(typeof AdminService.rejectQuestion).toBe('function');
  });

  it('should have approveAnswer method', () => {
    expect(typeof AdminService.approveAnswer).toBe('function');
  });

  it('should have rejectAnswer method', () => {
    expect(typeof AdminService.rejectAnswer).toBe('function');
  });

  it('should have getTotalUsers method', () => {
    expect(typeof AdminService.getTotalUsers).toBe('function');
  });

  it('should have getTotalQuestions method', () => {
    expect(typeof AdminService.getTotalQuestions).toBe('function');
  });

  it('should have getUsers method', () => {
    expect(typeof AdminService.getUsers).toBe('function');
  });

  it('should have deleteUser method', () => {
    expect(typeof AdminService.deleteUser).toBe('function');
  });

  it('should have getQuestionsWithAnswersAndUsers method', () => {
    expect(typeof AdminService.getQuestionsWithAnswersAndUsers).toBe('function');
  });

  it('should have deleteQuestion method', () => {
    expect(typeof AdminService.deleteQuestion).toBe('function');
  });

  it('should have deleteAnswer method', () => {
    expect(typeof AdminService.deleteAnswer).toBe('function');
  });
});
