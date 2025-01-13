import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingpermitdetailComponent } from './parkingpermitdetail.component';

describe('ParkingpermitdetailComponent', () => {
  let component: ParkingpermitdetailComponent;
  let fixture: ComponentFixture<ParkingpermitdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ParkingpermitdetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkingpermitdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
