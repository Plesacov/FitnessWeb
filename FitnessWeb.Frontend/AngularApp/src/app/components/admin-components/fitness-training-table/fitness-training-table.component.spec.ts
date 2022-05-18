import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FitnessTrainingTableComponent } from './fitness-training-table.component';

describe('FitnessTrainingTableComponent', () => {
  let component: FitnessTrainingTableComponent;
  let fixture: ComponentFixture<FitnessTrainingTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FitnessTrainingTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FitnessTrainingTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
