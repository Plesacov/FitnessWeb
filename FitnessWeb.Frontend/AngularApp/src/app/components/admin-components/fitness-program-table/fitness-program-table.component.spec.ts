import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FitnessProgramTableComponent } from './fitness-program-table.component';

describe('FitnessProgramTableComponent', () => {
  let component: FitnessProgramTableComponent;
  let fixture: ComponentFixture<FitnessProgramTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FitnessProgramTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FitnessProgramTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
