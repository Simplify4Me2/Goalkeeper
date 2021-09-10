import {
  Action,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
} from '@ngrx/store';

import * as fromRoot from '../../store';
import { Ranking } from '../models/ranking.model';
import * as fromActions from './home.actions';
import { Matchday } from '../models/matchday.model';

import moment from 'moment';

export const homeFeatureKey = 'home';

export interface HomeState {
  ranking: Ranking;
  matchday: Matchday;
}

export const initialState: HomeState = {
  ranking: null,
  matchday: null,
};

export interface State extends fromRoot.State {
  [homeFeatureKey]: HomeState;
}

const testReducer = createReducer(
  initialState,
  on(fromActions.getMatchdaySuccess, (state, { matchday }) => ({
    ...state,
    matchday: matchday,
  })),
  on(fromActions.getRankingSuccess, (state, { ranking }) => ({
    ...state,
    ranking: ranking,
  }))
);

export function reducer(state: HomeState | undefined, action: Action) {
  return testReducer(state, action);
}

export const selectHomeState =
  createFeatureSelector<State, HomeState>(homeFeatureKey);

// export const selectFixtures = createSelector(
//   selectHomeState,
//   (state) => state.fixtures
// );
export const selectRanking = createSelector(
  selectHomeState,
  (state) => state.ranking
);

export const selectMatchday = createSelector(selectHomeState, (state) => state.matchday);

// export const selectMatchday = createSelector(selectHomeState, (state) => ({
//   ...state.matchday,
//   matches: state.matchday?.matches.map((match) => ({
//     ...match,
//     date: moment(match.date).format('DD/MM'),
//   })),
// }));
