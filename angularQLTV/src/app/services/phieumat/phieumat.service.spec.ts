/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhieumatService } from './phieumat.service';

describe('Service: Phieumat', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhieumatService]
    });
  });

  it('should ...', inject([PhieumatService], (service: PhieumatService) => {
    expect(service).toBeTruthy();
  }));
});
