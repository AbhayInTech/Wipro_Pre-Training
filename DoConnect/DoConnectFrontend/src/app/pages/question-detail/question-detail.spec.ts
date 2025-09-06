import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

import { QuestionDetail } from './question-detail';

describe('QuestionDetail', () => {
  let component: QuestionDetail;
  let fixture: ComponentFixture<QuestionDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionDetail],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: {
                get: () => '1',
              },
            },
          },
        },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(QuestionDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
