import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FitnessExerciseTableComponent } from './fitness-exercise-table.component';

describe('FitnessExerciseTableComponent', () => {
  let component: FitnessExerciseTableComponent;
  let fixture: ComponentFixture<FitnessExerciseTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FitnessExerciseTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FitnessExerciseTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
