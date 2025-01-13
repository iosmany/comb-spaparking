import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingareasviewComponent } from './parkingareasview.component';

describe('ParkingareasviewComponent', () => {
  let component: ParkingareasviewComponent;
  let fixture: ComponentFixture<ParkingareasviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ParkingareasviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkingareasviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
