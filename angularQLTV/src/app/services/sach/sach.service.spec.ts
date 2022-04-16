/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SachService } from './sach.service';

describe('Service: Sach', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SachService]
    });
  });

  it('should ...', inject([SachService], (service: SachService) => {
    expect(service).toBeTruthy();
  }));
});
