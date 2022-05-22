import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditFitnessExerciseComponent } from './add-edit-fitness-exercise.component';

describe('AddEditFitnessExerciseComponent', () => {
  let component: AddEditFitnessExerciseComponent;
  let fixture: ComponentFixture<AddEditFitnessExerciseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditFitnessExerciseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditFitnessExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
