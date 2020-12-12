import { createAction, props } from "@ngrx/store";
import { Team } from "../../shared/models/team.model";

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