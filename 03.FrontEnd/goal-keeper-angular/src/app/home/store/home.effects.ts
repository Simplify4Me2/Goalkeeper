import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { Fixture } from '../models/fixture.model';

import { getFixtures, getFixturesSuccess, getFixturesFail } from './home.actions';
import { FixturesService } from './services/fixtures.service';

@Injectable()
export class HomeEffects {

    constructor(private actions: Actions, private service: FixturesService) {}

    getFixtures = createEffect(() => 
        this.actions.pipe(
            ofType(getFixtures),
            switchMap(() => 
                this.service.get().pipe(
                    map((fixtures: Fixture[]) => getFixturesSuccess({ fixtures })),
                    catchError(() => of(getFixturesFail()))
                )
            )
        )
    );
}