import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import { RequestResult } from 'src/app/shared/request-result';
import { Team } from '../models';
import { TeamsService } from '../store/services/teams.service';
import * as fromActions from '../store/team.actions';

@Injectable()
export class TeamEffects {

    constructor(private actions: Actions, private service: TeamsService) { }

    getTeam = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.getTeam),
            switchMap((props) =>
                this.service.getTeam(props.name).pipe(
                    map((request: RequestResult<Team>) => fromActions.getTeamSuccess({ team: request.data })),
                    catchError(() => of(fromActions.getTeamFail())
                    ))
            )
        )
    );

    // getPlayers = createEffect(() =>
    //     this.actions.pipe(
    //         ofType(fromActions.getPlayers),
    //         switchMap((props) =>
    //             this.service.getPlayers(props.teamId).pipe(
    //                 map((players: Player[]) => fromActions.getPlayersSuccess({ players })),
    //                 catchError(() => of(fromActions.getPlayersFail())
    //                 ))
    //         )
    //     )
    // );
}