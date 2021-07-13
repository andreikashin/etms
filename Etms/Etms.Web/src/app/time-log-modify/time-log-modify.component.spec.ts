import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeLogModifyComponent } from './time-log-modify.component';

describe('TimeLogModifyComponent', () => {
  let component: TimeLogModifyComponent;
  let fixture: ComponentFixture<TimeLogModifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeLogModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeLogModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
