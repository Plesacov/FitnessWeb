import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditFitnessTrainingComponent } from './add-edit-fitness-training.component';

describe('AddEditFitnessTrainingComponent', () => {
  let component: AddEditFitnessTrainingComponent;
  let fixture: ComponentFixture<AddEditFitnessTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditFitnessTrainingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditFitnessTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
