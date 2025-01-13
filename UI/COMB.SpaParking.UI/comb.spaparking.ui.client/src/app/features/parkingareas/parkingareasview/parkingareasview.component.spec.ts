import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingareasviewComponent } from './parkingareasview.component';
import { provideHttpClient } from '@angular/common/http';
import { ParkingAreaService } from '../parkingarea.service';

describe('ParkingareasviewComponent', () => {
  let component: ParkingareasviewComponent;
  let fixture: ComponentFixture<ParkingareasviewComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
          imports: [ParkingareasviewComponent],
          providers: [provideHttpClient(), ParkingAreaService],
      });
    fixture = TestBed.createComponent(ParkingareasviewComponent);
    fixture.autoDetectChanges();
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
