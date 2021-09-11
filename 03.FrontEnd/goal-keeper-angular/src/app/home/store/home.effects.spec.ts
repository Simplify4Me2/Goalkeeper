import { fakeAsync, TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Actions } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { hot, cold } from 'jasmine-marbles';

import { HomeEffects } from './home.effects';
import { RankingService } from './services/ranking.service';
import * as fromActions from './home.actions';
import { Ranking } from '../models/ranking.model';
import { RequestResult } from 'src/app/shared/request-result';
import { MatchService } from './services/match.service';

describe('HomeEffects', () => {

    let actions: Observable<any>;
    let effects: HomeEffects;
    let rankingService: RankingService;
    let matchService: MatchService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                HomeEffects,
                {
                    provide: RankingService,
                    useValue: {
                        get: jest.fn()
                    }
                },
                {
                    provide: MatchService,
                    useValue: {
                        get: jest.fn(),
                        getLastMatchday: jest.fn()
                    }
                },
                provideMockActions(() => actions)
            ]
        });

        actions = TestBed.inject(Actions);
        effects = TestBed.inject(HomeEffects);
        rankingService = TestBed.inject(RankingService);
        matchService = TestBed.inject(MatchService);
    });

    describe('getRankings', () => {
        it('should return a getRankingsSuccess, with data, on success', fakeAsync(() => {
            const request: RequestResult<Ranking> = {
                data: {
                    competitionName: 'Test League',
                    teamRankings: [{ teamId: 1, teamName: 'Test Team', points: 0, gamesPlayed: 0 }]
                },
                messages: []
            };

            const action = fromActions.getRanking();
            const completion = fromActions.getRankingSuccess({ ranking: request.data });

            actions = hot('--a', { a: action });
            const response = cold('--b|', { b: request });
            const expected = cold('----c', { c: completion });
            rankingService.get = jest.fn(() => response);

            expect(effects.getRanking).toBeObservable(expected)
        }));

        it('should return a getRankingsFail, without data, on fail', () => {
            const action = fromActions.getRanking();
            const completion = fromActions.getRankingFail();

            actions = hot('--a', { a: action });
            const response = cold('--#|');
            const expected = cold('----c', { c: completion });
            rankingService.get = jest.fn(() => response);

            expect(effects.getRanking).toBeObservable(expected)
        });
    });
});