/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhieumuonService } from './phieumuon.service';

describe('Service: Phieumuon', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhieumuonService]
    });
  });

  it('should ...', inject([PhieumuonService], (service: PhieumuonService) => {
    expect(service).toBeTruthy();
  }));
});
