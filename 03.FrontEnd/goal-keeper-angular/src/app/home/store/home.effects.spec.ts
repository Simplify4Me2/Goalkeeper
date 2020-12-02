import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Actions } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { hot, cold } from 'jasmine-marbles';

import { HomeEffects } from './home.effects';
import { RankingsService } from './services/rankings.service';
import { getRankings, getRankingsSuccess } from './home.actions';

describe('HomeEffects', () => {

    let actions: Observable<any>;
    let effects: HomeEffects;
    let service: any;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                HomeEffects,
                {
                    provide: RankingsService,
                    useValue: {
                        get: jest.fn()
                    }
                },
                provideMockActions(() => actions)
            ]
        });

        actions = TestBed.inject(Actions);
        effects = TestBed.inject(HomeEffects);
        service = TestBed.inject(RankingsService);
        
    });

    describe('getRankings', () => {
        it('should return a getRankingsSuccess, with data, on success', () => {
            const ranking = [
                { position: 1, team: 'Club Brugge', points: 70 },
                { position: 2, team: 'KAA Gent', points: 55 },]
            
            const action = getRankings();
            const completion = getRankingsSuccess({ rankings: ranking });

            actions = hot('--a', { a: action });
            const response = cold('--b|', { b: ranking });
            const expected = cold('----c', { c: completion });
            service.get = jest.fn(() => response);


            expect(effects.getRankings).toBeObservable(expected)
        })
    });
});