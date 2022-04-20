/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhieumuonComponent } from './phieumuon.component';

describe('PhieumuonComponent', () => {
  let component: PhieumuonComponent;
  let fixture: ComponentFixture<PhieumuonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhieumuonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhieumuonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
