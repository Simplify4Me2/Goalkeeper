import { Action, createReducer, on } from '@ngrx/store';

import * as fromRoot from '../../store';
import { Team } from '../../team/models';
import * as fromActions from './team.actions';

export const teamFeatureKey = 'team';

export interface TeamState {
    team: Team;
}

export const initialState: TeamState = {
    team: null,
}

export interface State extends fromRoot.State {
    [teamFeatureKey]: TeamState
}

export const teamReducer = createReducer(initialState,
    on(fromActions.getTeamSuccess, (state, { team }) => { console.log(team); return ({ ...state, team: team })}),
    );

export function reducer(state: TeamState, action: Action) {
    return teamReducer(state, action);
}
