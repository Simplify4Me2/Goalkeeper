import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromActions from '../store/home.actions';
import * as fromStore from '../store';
import { Observable } from 'rxjs';
import { Ranking } from '../models/ranking.model';
import { Matchday } from '../models/matchday.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.container.html',
  styleUrls: ['./home.container.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
  ranking: Observable<Ranking>;
  lastMatchday: Observable<Matchday>;

  constructor(private store: Store) {}

  ngOnInit(): void {
      this.store.dispatch(fromActions.getRanking());
      this.store.dispatch(fromActions.getCurrentMatchday());

      
      this.ranking = this.store.select(fromStore.selectRanking);
      this.lastMatchday = this.store.select(fromStore.selectLastMatchday);
  }

  selectMatchday(matchday: number) {
    this.store.dispatch(fromActions.getMatchday({ day: matchday }));
  }
}
