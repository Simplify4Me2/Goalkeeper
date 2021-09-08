import { createAction, props } from '@ngrx/store';
import { Matchday } from '../models/matchday.model';
import { Ranking } from '../models/ranking.model';

export const getMatchday = createAction(
    '[Home/Container] Get Matchday',
    props<{ day: number}>()
);

export const getMatchdaySuccess = createAction(
    '[Home/API] Get Matchday Success',
    props<{ matchday: Matchday }>()
);

export const getMatchdayFail = createAction(
    '[Home/API] Get Matchday Failed',
);

export const getRanking = createAction(
    '[Home/Container] Get Ranking'
);

export const getRankingSuccess = createAction(
    '[Home/API] Get Ranking Success',
    props<{ ranking: Ranking }>()
);

export const getRankingFail = createAction(
    '[Home/API] Get Ranking Failed',
);

export const getCurrentMatchday = createAction(
    '[Home/Container] Get Current Matchday'
);