import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import { RequestResult } from 'src/app/shared/request-result';
import { Fixture } from '../models/fixture.model';
import { Ranking } from '../models/ranking.model';
import * as fromActions from './home.actions';
import { FixturesService } from './services/fixtures.service';
import { RankingService } from './services/ranking.service';

@Injectable()
export class HomeEffects {

    constructor(private actions: Actions, private fixturesService: FixturesService, private rankingService: RankingService) { }

    getFixtures = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.getFixtures),
            switchMap(() =>
                this.fixturesService.get().pipe(
                    map((fixtures: Fixture[]) => fromActions.getFixturesSuccess({ fixtures })),
                    catchError(() => of(fromActions.getFixturesFail()))
                )
            )
        )
    );

    getRanking = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.getRanking),
            switchMap(() =>
                this.rankingService.get().pipe(
                    map((result: RequestResult<Ranking>) => fromActions.getRankingSuccess({ ranking: result.data })),
                    catchError(() => of(fromActions.getRankingFail()))
                )
            )
        )
    );
}