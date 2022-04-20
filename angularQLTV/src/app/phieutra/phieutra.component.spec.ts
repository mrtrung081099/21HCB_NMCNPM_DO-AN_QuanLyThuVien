/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhieutraComponent } from './phieutra.component';

describe('PhieutraComponent', () => {
  let component: PhieutraComponent;
  let fixture: ComponentFixture<PhieutraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhieutraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhieutraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
