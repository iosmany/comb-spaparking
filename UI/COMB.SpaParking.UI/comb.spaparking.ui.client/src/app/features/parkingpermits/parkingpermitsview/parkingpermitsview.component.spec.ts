import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingpermisviewComponent } from './parkingpermitsview.component';

describe('ParkingpermisviewComponent', () => {
  let component: ParkingpermisviewComponent;
  let fixture: ComponentFixture<ParkingpermisviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ParkingpermisviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkingpermisviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
