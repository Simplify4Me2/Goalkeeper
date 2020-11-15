import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.container';
import { FixtureComponent } from '../components/fixture/fixture.component';
import { RankingComponent } from '../components/ranking/ranking.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeComponent, FixtureComponent, RankingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
