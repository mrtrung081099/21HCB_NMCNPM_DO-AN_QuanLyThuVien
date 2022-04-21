/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ThanhlysachService } from './thanhlysach.service';

describe('Service: Thanhlysach', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ThanhlysachService]
    });
  });

  it('should ...', inject([ThanhlysachService], (service: ThanhlysachService) => {
    expect(service).toBeTruthy();
  }));
});
