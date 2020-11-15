import { createAction, props } from '@ngrx/store';
import { Fixture } from '../models/fixture.model';

export const getFixtures = createAction(
    '[Test] Get Fixtures'
);

export const getFixturesSuccess = createAction(
    '[Test] Get Fixtures Success',
    props<{ fixtures: Fixture[] }>()
);

export const getFixturesFail = createAction(
    '[Test] Get Fixtures Success',
    // props<{ fixtures: Fixture[] }>()
);