/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhieumatComponent } from './phieumat.component';

describe('PhieumatComponent', () => {
  let component: PhieumatComponent;
  let fixture: ComponentFixture<PhieumatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhieumatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhieumatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
