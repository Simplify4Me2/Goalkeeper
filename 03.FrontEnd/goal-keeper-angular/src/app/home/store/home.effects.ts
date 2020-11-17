import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import { Fixture } from '../models/fixture.model';
import { Ranking } from '../models/ranking.model';
import { getFixtures, getFixturesSuccess, getFixturesFail, getRankings, getRankingsSuccess, getRankingsFail } from './home.actions';
import { FixturesService } from './services/fixtures.service';
import { RankingsService } from './services/rankings.service';

@Injectable()
export class HomeEffects {

    constructor(private actions: Actions, private fixturesService: FixturesService, private rankingsService: RankingsService) {}

    getFixtures = createEffect(() => 
        this.actions.pipe(
            ofType(getFixtures),
            switchMap(() => 
                this.fixturesService.get().pipe(
                    map((fixtures: Fixture[]) => getFixturesSuccess({ fixtures })),
                    catchError(() => of(getFixturesFail()))
                )
            )
        )
    );

    getRankings = createEffect(() => 
        this.actions.pipe(
            ofType(getRankings),
            switchMap(() => 
                this.rankingsService.get().pipe(
                    map((rankings: Ranking[]) => getRankingsSuccess({ rankings })),
                    catchError(() => of(getRankingsFail()))
                )
            )
        )
    );
}