import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScopeStylingComponent } from './scope-styling.component';

describe('ScopeStylingComponent', () => {
  let component: ScopeStylingComponent;
  let fixture: ComponentFixture<ScopeStylingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScopeStylingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScopeStylingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
