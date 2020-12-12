import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Team } from '../../shared/models/team.model';

import { TeamsService } from '../store/services/teams.service';
import { getTeam, getTeamFail, getTeamSuccess } from '../store/team.actions';

@Injectable()
export class TeamEffects {

    constructor(private actions: Actions, private service: TeamsService) { }

    getTeam = createEffect(() =>
        this.actions.pipe(
            ofType(getTeam),
            switchMap((props) =>
                this.service.get(props.id).pipe(
                    map((team: Team) => getTeamSuccess({ team })),
                    catchError(() => of(getTeamFail())
                    ))
            )
        )
    );
}