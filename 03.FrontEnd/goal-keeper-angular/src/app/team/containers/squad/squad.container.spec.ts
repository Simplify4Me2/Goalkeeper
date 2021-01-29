import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { SquadContainerComponent } from './squad.container';
import { TeamPlayersComponent } from '../../components/team-players/team-players.component';

describe('SquadContainer', () => {
  let component: SquadContainerComponent;
  let fixture: ComponentFixture<SquadContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [SquadContainerComponent, TeamPlayersComponent],
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
    fixture = TestBed.createComponent(SquadContainerComponent);
    component = fixture.componentInstance;
  });
  
  it('should create', () => {
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
