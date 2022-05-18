import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditFitnessProgramComponent } from './add-edit-fitness-program.component';

describe('AddEditFitnessProgramComponent', () => {
  let component: AddEditFitnessProgramComponent;
  let fixture: ComponentFixture<AddEditFitnessProgramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditFitnessProgramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditFitnessProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
