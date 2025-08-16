import { TestBed } from '@angular/core/testing';

import { EventDataService } from './event-data';

describe('EventData', () => {
  let service: EventDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
