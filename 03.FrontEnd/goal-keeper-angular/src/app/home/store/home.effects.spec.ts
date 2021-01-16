import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Actions } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { hot, cold } from 'jasmine-marbles';

import { HomeEffects } from './home.effects';
import { RankingService } from './services/ranking.service';
import { getRanking, getRankingSuccess } from './home.actions';
import { Ranking } from '../models/ranking.model';
import { RequestResult } from 'src/app/shared/request-result';

describe('HomeEffects', () => {

    let actions: Observable<any>;
    let effects: HomeEffects;
    let service: any;

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
                provideMockActions(() => actions)
            ]
        });

        actions = TestBed.inject(Actions);
        effects = TestBed.inject(HomeEffects);
        service = TestBed.inject(RankingService);
        
    });

    describe('getRankings', () => {
        it('should return a getRankingsSuccess, with data, on success', () => {
            // const ranking: Ranking = [
            //     { position: 1, team: 'Club Brugge', points: 70 },
            //     { position: 2, team: 'KAA Gent', points: 55 },]
            
            const request: RequestResult<Ranking> = {
                data: {
                    id: 1,
                    competitionName: 'Test League',
                    teams: []
                },
                messages: []
            }

            const action = getRanking();
            const completion = getRankingSuccess({ ranking: request.data });

            actions = hot('--a', { a: action });
            const response = cold('--b|', { b: request });
            const expected = cold('----c', { c: completion });
            service.get = jest.fn(() => response);


            expect(effects.getRanking).toBeObservable(expected)
        })
    });
});