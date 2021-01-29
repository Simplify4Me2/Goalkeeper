import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { FixturesContainerComponent } from './fixtures.container';

describe('FixturesComponent', () => {
  let component: FixturesContainerComponent;
  let fixture: ComponentFixture<FixturesContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [ FixturesContainerComponent ],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            parent: {
              snapshot: {
                paramMap: convertToParamMap({
                  id: '112'
                })
              }
            }
          }
        },
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixturesContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
