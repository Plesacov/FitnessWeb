import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FitnessTipProgramTableComponent } from './fitness-tip-program-table.component';

describe('FitnessTipProgramTableComponent', () => {
  let component: FitnessTipProgramTableComponent;
  let fixture: ComponentFixture<FitnessTipProgramTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FitnessTipProgramTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FitnessTipProgramTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
