import { Action, createReducer, on } from '@ngrx/store';

import * as fromRoot from '../../store';
import { Player, Team } from '../../team/models';
import * as fromActions from './team.actions';

export const teamFeatureKey = 'team';

export interface TeamState {
    team: Team;
    // playerId: number;
    // players: Player[];
}

export const initialState: TeamState = {
    team: null,
    // playerId: 1,
    // players: [],
}

export interface State extends fromRoot.State {
    [teamFeatureKey]: TeamState
}

const teamReducer = createReducer(initialState,
    on(fromActions.getTeamSuccess, (state, { team }) => ({ ...state, team: team })),
    // on(fromActions.getPlayersSuccess, (state, { players }) => ({ ...state, players: players })),
    );

export function reducer(state: TeamState, action: Action) {
    return teamReducer(state, action);
}
