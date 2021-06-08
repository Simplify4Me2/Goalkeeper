import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import { RequestResult } from 'src/app/shared/request-result';
import { Matchday } from '../models/matchday.model';
import { Ranking } from '../models/ranking.model';
import * as fromActions from './home.actions';
import { MatchService } from './services/match.service';
import { RankingService } from './services/ranking.service';

@Injectable()
export class HomeEffects {

    constructor(private actions: Actions, private matchService: MatchService, private rankingService: RankingService) { }

    getMatchday = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.getMatchday),
            switchMap((action) =>
                this.matchService.getMatchday(action.day).pipe(
                    map((result: RequestResult<Matchday>) => fromActions.getMatchdaySuccess({ matchday: result.data })),
                    catchError(() => of(fromActions.getMatchdayFail()))
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

    getLastMatchday = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.getLastMatchday),
            switchMap(() =>
                this.matchService.getLastMatchday().pipe(
                    map((result: RequestResult<Matchday>) => fromActions.getLastMatchdaySuccess({ matchday: result.data })),
                    catchError(() => of(fromActions.getLastMatchdayFail()))
                )
            )
        )
    );
}