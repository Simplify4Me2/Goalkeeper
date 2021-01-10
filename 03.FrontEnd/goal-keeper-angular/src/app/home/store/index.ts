import { Action, createFeatureSelector, createReducer, createSelector, on } from '@ngrx/store';

import * as fromRoot from '../../store';
import { Fixture } from '../models/fixture.model';
import { Ranking } from '../models/ranking.model';
import * as fromActions from './home.actions';

export const homeFeatureKey = 'home';

export interface HomeState {
    fixtures: Fixture[];
    ranking: Ranking;
};

export const initialState: HomeState = {
    fixtures: [],
    ranking: null,
};

export interface State extends fromRoot.State {
    [homeFeatureKey]: HomeState;
}

const testReducer = createReducer(initialState,
    on(fromActions.getFixturesSuccess, (state, { fixtures }) => ({ ...state, fixtures: fixtures })),
    on(fromActions.getRankingSuccess, (state, { ranking }) => ({ ...state, ranking: ranking })),
    );

export function reducer(state: HomeState | undefined, action: Action) {
    return testReducer(state, action);
}

export const selectHomeState = createFeatureSelector<State, HomeState>(
    homeFeatureKey
);

export const selectFixtures = createSelector(selectHomeState, (state) => state.fixtures);
export const selectRanking = createSelector(selectHomeState, (state) => state.ranking);
