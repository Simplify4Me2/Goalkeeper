import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';

import { SquadContainerComponent } from './squad.container';
import { TeamPlayersComponent, PlayerCardComponent } from '../../components';

describe('SquadContainer', () => {
  let component: SquadContainerComponent;
  let fixture: ComponentFixture<SquadContainerComponent>;
  let store: MockStore;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [SquadContainerComponent, TeamPlayersComponent, PlayerCardComponent],
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
        provideMockStore()
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SquadContainerComponent);
    component = fixture.componentInstance;
    store = TestBed.inject(MockStore);
  });
  
  it('should create', () => {
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
