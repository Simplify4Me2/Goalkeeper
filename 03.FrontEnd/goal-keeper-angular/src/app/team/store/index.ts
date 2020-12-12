import { Action, createFeatureSelector, createReducer, createSelector, on } from '@ngrx/store';
import * as fromRoot from '../../store';
import { Team } from '../../shared/models/team.model';
import { getTeamSuccess } from './team.actions';

export const teamFeatureKey = 'team';

export interface TeamState {
    team: Team;
    playerId: number;
}

export const initialState: TeamState = {
    team: null,
    playerId: 1,
}

export interface State extends fromRoot.State {
    [teamFeatureKey]: TeamState
}

const teamReducer = createReducer(initialState,
    on(getTeamSuccess, (state, { team }) => ({ ...state, team: team })),
    );

export function reducer(state: TeamState, action: Action) {
    return teamReducer(state, action);
}

const selectTeamState = createFeatureSelector<State, TeamState>(teamFeatureKey);

export const selectTeam = createSelector(selectTeamState, (state) => state.team);