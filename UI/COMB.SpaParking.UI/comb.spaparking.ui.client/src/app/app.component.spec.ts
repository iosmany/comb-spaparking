import { HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { provideRouter, ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';


describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;
  let activatedRoute: ActivatedRoute;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent], // Import the standalone component directly
      providers: [HttpTestingController, 
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: {
                get: (key: string) => 'mockValue', // Mock snapshot parameters
              },
            },
            queryParams: of({ search: 'test' }), // Mock query parameters
            params: of({ id: '123' }), // Mock route parameters
          },
        },
      ],
    }).compileComponents();
     fixture = TestBed.createComponent(AppComponent);
     fixture.autoDetectChanges();
  });

  beforeEach(() => {
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    activatedRoute = TestBed.inject(ActivatedRoute);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });
  
});