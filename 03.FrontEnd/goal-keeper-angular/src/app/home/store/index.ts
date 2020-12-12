import { Action, createFeatureSelector, createReducer, createSelector, on } from '@ngrx/store';

import * as fromRoot from '../../store';
import { Fixture } from '../models/fixture.model';
import { Ranking } from '../models/ranking.model';
import { getFixtures, getFixturesSuccess, getRankingsSuccess } from './home.actions';

export const homeFeatureKey = 'home';

export interface HomeState {
    // home: number;
    // away: number;
    fixtures: Fixture[];
    rankings: Ranking[];
};

export const initialState: HomeState = {
    // home: 0,
    // away: 0,
    fixtures: [],
    rankings: [],
};

export interface State extends fromRoot.State {
    [homeFeatureKey]: HomeState;
}

const testReducer = createReducer(initialState,
    // on(getFixtures, state => ({ ...state, home: state.home + 1 })),
    on(getFixturesSuccess, (state, { fixtures }) => ({ ...state, fixtures: fixtures })),
    on(getRankingsSuccess, (state, { rankings }) => ({ ...state, rankings: rankings })),
    );

export function reducer(state: HomeState | undefined, action: Action) {
    return testReducer(state, action);
}

export const selectHomeState = createFeatureSelector<State, HomeState>(
    homeFeatureKey
);

export const selectFixtures = createSelector(selectHomeState, (state) => state.fixtures);
export const selectRankings = createSelector(selectHomeState, (state) => state.rankings);
