/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhieutraService } from './phieutra.service';

describe('Service: Phieutra', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhieutraService]
    });
  });

  it('should ...', inject([PhieutraService], (service: PhieutraService) => {
    expect(service).toBeTruthy();
  }));
});
