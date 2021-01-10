import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Actions } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { hot, cold } from 'jasmine-marbles';

import { HomeEffects } from './home.effects';
import { RankingService } from './services/ranking.service';
import { getRanking, getRankingSuccess } from './home.actions';
import { Ranking } from '../models/ranking.model';

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
            
            const ranking: Ranking = {
                teams: []
            }

            const action = getRanking();
            const completion = getRankingSuccess({ ranking: ranking });

            actions = hot('--a', { a: action });
            const response = cold('--b|', { b: ranking });
            const expected = cold('----c', { c: completion });
            service.get = jest.fn(() => response);


            expect(effects.getRanking).toBeObservable(expected)
        })
    });
});