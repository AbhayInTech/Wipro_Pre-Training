import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CombinedList } from './combined-list';

describe('CombinedList', () => {
  let component: CombinedList;
  let fixture: ComponentFixture<CombinedList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CombinedList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CombinedList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
