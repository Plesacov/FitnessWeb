import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditFitnessTipComponent } from './add-edit-fitness-tip.component';

describe('AddEditFitnessTipComponent', () => {
  let component: AddEditFitnessTipComponent;
  let fixture: ComponentFixture<AddEditFitnessTipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditFitnessTipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditFitnessTipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
