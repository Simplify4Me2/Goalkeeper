import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { Fixture } from '../models/fixture.model';
import { getFixtures, getRankings } from '../store/home.actions';
import * as fromHome from '../store';
import { Observable } from 'rxjs';
import { Ranking } from '../models/ranking.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.container.html',
  styleUrls: ['./home.container.sass'],
})
export class HomeComponent implements OnInit {
  fixtures: Observable<Fixture[]>;
  rankings: Observable<Ranking[]>;

  constructor(private store: Store) {}

  ngOnInit(): void {
      this.store.dispatch(getFixtures());
      this.store.dispatch(getRankings());
      
      this.fixtures = this.store.select(fromHome.selectFixtures);
      this.rankings = this.store.select(fromHome.selectRankings);
      console.log('fixtures: ', this.fixtures);
      console.log('rankings: ', this.rankings);
  }
}
