import { Action, createFeatureSelector, createReducer, createSelector } from '@ngrx/store';
import * as fromRoot from '../../store';

export const teamFeatureKey = 'team';

export interface TeamState {
    team: string;
    playerId: number;
}

export const initialState: TeamState = {
    team: 'Foo',
    playerId: 1,
}

export interface State extends fromRoot.State {
    [teamFeatureKey]: TeamState
}

const teamReducer = createReducer(initialState,
    );

export function reducer(state: TeamState, action: Action) {
    return teamReducer(state, action);
}

const selectTeamState = createFeatureSelector<State, TeamState>(teamFeatureKey);

export const selectTeam = createSelector(selectTeamState, (state) => state.team);