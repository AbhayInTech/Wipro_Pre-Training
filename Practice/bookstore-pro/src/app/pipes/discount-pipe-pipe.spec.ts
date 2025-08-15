import { DiscountPipe } from './discount-pipe-pipe';

describe('DiscountPipe', () => {
  it('should apply default 10% discount', () => {
    const pipe = new DiscountPipe();
    expect(pipe.transform(100)).toBe(90);
  });

  it('should apply custom discount', () => {
    const pipe = new DiscountPipe();
    expect(pipe.transform(200, 25)).toBe(150);
  });
});
