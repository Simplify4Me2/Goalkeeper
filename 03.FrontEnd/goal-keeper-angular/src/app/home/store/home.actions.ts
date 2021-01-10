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

export const getRanking = createAction(
    '[Home/Container] Get Ranking'
);

export const getRankingSuccess = createAction(
    '[Home/API] Get Ranking Success',
    props<{ ranking: Ranking }>()
);

export const getRankingFail = createAction(
    '[Home/API] Get Ranking Success',
);