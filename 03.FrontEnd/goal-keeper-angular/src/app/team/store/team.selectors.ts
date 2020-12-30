import { createFeatureSelector, createSelector } from '@ngrx/store';

import { State, teamFeatureKey, TeamState } from './team.reducer';

export const selectTeamState = createFeatureSelector<State, TeamState>(teamFeatureKey);

export const selectTeam = createSelector(selectTeamState, (state) => state.team);
export const selectPlayers = createSelector(selectTeamState, (state) => state.players);
