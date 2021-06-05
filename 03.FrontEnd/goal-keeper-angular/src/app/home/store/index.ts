import {
  Action,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
} from '@ngrx/store';

import * as fromRoot from '../../store';
import { Match } from '../../shared/models/match.model';
import { Ranking } from '../models/ranking.model';
import * as fromActions from './home.actions';
import { Matchday } from '../models/matchday.model';

import moment from 'moment';

export const homeFeatureKey = 'home';

export interface HomeState {
  fixtures: Match[];
  ranking: Ranking;
  lastMatchday: Matchday;
}

export const initialState: HomeState = {
  fixtures: [],
  ranking: null,
  lastMatchday: null,
};

export interface State extends fromRoot.State {
  [homeFeatureKey]: HomeState;
}

const testReducer = createReducer(
  initialState,
  on(fromActions.getMatchesSuccess, (state, { fixtures }) => ({
    ...state,
    fixtures: fixtures,
  })),
  on(fromActions.getRankingSuccess, (state, { ranking }) => ({
    ...state,
    ranking: ranking,
  })),
  on(fromActions.getLastMatchdaySuccess, (state, { matchday }) => ({
    ...state,
    lastMatchday: matchday,
  }))
);

export function reducer(state: HomeState | undefined, action: Action) {
  return testReducer(state, action);
}

export const selectHomeState =
  createFeatureSelector<State, HomeState>(homeFeatureKey);

export const selectFixtures = createSelector(
  selectHomeState,
  (state) => state.fixtures
);
export const selectRanking = createSelector(
  selectHomeState,
  (state) => state.ranking
);
// export const selectLastMatchday = createSelector(selectHomeState, (state) => state.lastMatchday);

export const selectLastMatchday = createSelector(selectHomeState, (state) => ({
  ...state.lastMatchday,
  matches: state.lastMatchday?.matches.map((match) => ({
    ...match,
    date: moment(match.date).format('DD/MM'),
  })),
}));
