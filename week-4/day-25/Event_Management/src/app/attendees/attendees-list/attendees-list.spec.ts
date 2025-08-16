import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendeesList } from './attendees-list';

describe('AttendeesList', () => {
  let component: AttendeesList;
  let fixture: ComponentFixture<AttendeesList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttendeesList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttendeesList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
