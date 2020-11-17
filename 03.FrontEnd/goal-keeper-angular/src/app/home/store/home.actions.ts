import { createAction, props } from '@ngrx/store';
import { Fixture } from '../models/fixture.model';
import { Ranking } from '../models/ranking.model';

export const getFixtures = createAction(
    '[Home/Container] Get Fixtures'
);

export const getFixturesSuccess = createAction(
    '[Home/API] Get Fixtures Success',
    props<{ fixtures: Fixture[] }>()
);

export const getFixturesFail = createAction(
    '[Home/API] Get Fixtures Success',
);

export const getRankings = createAction(
    '[Home/Container] Get Rankings'
);

export const getRankingsSuccess = createAction(
    '[Home/API] Get Rankings Success',
    props<{ rankings: Ranking[] }>()
);

export const getRankingsFail = createAction(
    '[Home/API] Get Rankings Success',
);