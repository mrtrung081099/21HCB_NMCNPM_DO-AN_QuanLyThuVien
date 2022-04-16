/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SachComponent } from './sach.component';

describe('SachComponent', () => {
  let component: SachComponent;
  let fixture: ComponentFixture<SachComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SachComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SachComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
