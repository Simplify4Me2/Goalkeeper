import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { Match } from '../../shared/models/match.model';
import * as fromActions from '../store/home.actions';
import * as fromStore from '../store';
import { Observable } from 'rxjs';
import { Ranking } from '../models/ranking.model';
import { Matchday } from '../models/matchday.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.container.html',
  styleUrls: ['./home.container.sass'],
})
export class HomeComponent implements OnInit {
  fixtures: Observable<Match[]>;
  ranking: Observable<Ranking>;
  lastMatchday: Observable<Matchday>;

  constructor(private store: Store) {}

  ngOnInit(): void {
      this.store.dispatch(fromActions.getMatches());
      this.store.dispatch(fromActions.getRanking());
      this.store.dispatch(fromActions.getLastMatchday());

      
      this.fixtures = this.store.select(fromStore.selectFixtures);
      this.ranking = this.store.select(fromStore.selectRanking);
      this.lastMatchday = this.store.select(fromStore.selectLastMatchday);
      // console.log('fixtures: ', this.fixtures);
      // console.log('ranking: ', this.ranking);
  }
}
