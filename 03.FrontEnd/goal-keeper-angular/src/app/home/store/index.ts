import { Action, createFeatureSelector, createReducer, on } from '@ngrx/store';

import * as fromRoot from '../../store';
import { Fixture } from '../models/fixture.model';
import { getFixtures } from './home.actions';

export const homeFeatureKey = 'home';

export interface HomeState {
    home: number;
    away: number;
    fixtures: Fixture[];
};

export const initialState: HomeState = {
    home: 0,
    away: 0,
    fixtures: [],
};

export interface State extends fromRoot.State {
    [homeFeatureKey]: HomeState;
}

const testReducer = createReducer(initialState,
    on(getFixtures, state => ({ ...state, home: state.home + 1 })),
    );

export function reducer(state: HomeState | undefined, action: Action) {
    return testReducer(state, action);
}

export const selectHomeState = createFeatureSelector<State,  State>(
    homeFeatureKey
);
