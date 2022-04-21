/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhieuphatService } from './phieuphat.service';

describe('Service: Phieuphat', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhieuphatService]
    });
  });

  it('should ...', inject([PhieuphatService], (service: PhieuphatService) => {
    expect(service).toBeTruthy();
  }));
});
