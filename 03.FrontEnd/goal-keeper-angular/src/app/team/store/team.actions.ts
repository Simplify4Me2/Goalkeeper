import { createAction, props } from '@ngrx/store';
import { Player, Team } from '../../team/models';

export const getTeam = createAction(
    '[TeamPage] Get Team',
    props<{ id: number }>()
);


export const getTeamSuccess = createAction(
    '[Team API] Get Team Success',
    props<{ team: Team }>()
);


export const getTeamFail = createAction(
    '[Team API] Get Team Fail'
);

// export const getPlayers = createAction(
//     '[TeamPage] Get Players',
//     props<{ teamId: number }>()
// );


// export const getPlayersSuccess = createAction(
//     '[Team API] Get Players Success',
//     props<{ players: Player[] }>()
// );


// export const getPlayersFail = createAction(
//     '[Team API] Get Players Fail'
// );