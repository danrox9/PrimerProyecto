import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedioComponent } from './medio.component';

describe('MedioComponent', () => {
  let component: MedioComponent;
  let fixture: ComponentFixture<MedioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MedioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
