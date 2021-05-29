import { createAction, props } from '@ngrx/store';
import { Match } from '../../shared/models/match.model';
import { Matchday } from '../models/matchday.model';
import { Ranking } from '../models/ranking.model';

export const getMatches = createAction(
    '[Home/Container] Get Matches'
);

export const getMatchesSuccess = createAction(
    '[Home/API] Get Matches Success',
    props<{ fixtures: Match[] }>()
);

export const getMatchesFail = createAction(
    '[Home/API] Get Matches Success',
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

export const getLastMatchday = createAction(
    '[Home/Container] Get Last Matchday'
);

export const getLastMatchdaySuccess = createAction(
    '[Home/API] Get Last Matchday Success',
    props<{ matchday: Matchday }>()
);

export const getLastMatchdayFail = createAction(
    '[Home/API] Get Last Matchday Success',
);