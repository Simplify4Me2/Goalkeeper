import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { Fixture } from '../../shared/models/fixture.model';
import { getFixtures, getRanking } from '../store/home.actions';
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
  ranking: Observable<Ranking>;

  constructor(private store: Store) {}

  ngOnInit(): void {
      this.store.dispatch(getFixtures());
      this.store.dispatch(getRanking());
      
      this.fixtures = this.store.select(fromHome.selectFixtures);
      this.ranking = this.store.select(fromHome.selectRanking);
      // console.log('fixtures: ', this.fixtures);
      // console.log('ranking: ', this.ranking);
  }
}
