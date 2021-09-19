import { Component } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { StatsContainerComponent } from './stats.container';
import { TeamCardsStatsComponent, TeamGoalsStatsComponent } from '../../components';


@Component({
  selector: "app-team-charts", template: ""
}) class MockTeamChartsComponent {}

describe('StatsContainer', () => {
  let component: StatsContainerComponent;
  let fixture: ComponentFixture<StatsContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [StatsContainerComponent, TeamCardsStatsComponent, TeamGoalsStatsComponent, MockTeamChartsComponent],
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
    fixture = TestBed.createComponent(StatsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
