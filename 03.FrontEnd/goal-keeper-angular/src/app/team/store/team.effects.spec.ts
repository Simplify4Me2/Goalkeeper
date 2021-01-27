import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Observable } from 'rxjs';
import { cold, hot } from 'jasmine-marbles';
import { Actions } from '@ngrx/effects';

import { Team } from 'src/app/team/models/team.model';
import { RequestResult } from 'src/app/shared/request-result';
import { TeamsService } from './services/teams.service';
import { TeamEffects } from './team.effects';
import * as fromActions from './team.actions';

describe('TeamEffects', () => {
    let actions: Observable<any>;
    let effects: TeamEffects;
    let service: TeamsService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                TeamEffects, 
                {
                    provide: TeamsService,
                    useValue: {
                        getTeam: jest.fn()
                    }
                },
                provideMockActions(() => actions)
            ]
        });

        actions = TestBed.inject(Actions);
        effects = TestBed.inject(TeamEffects);
        service = TestBed.inject(TeamsService);
    });

    describe('getTeam', () => {
        it('should return a getTeamSuccess, with data, on success', () => {
            const request: RequestResult<Team> = {
                data: {
                    id: 3,
                    name: 'FC De Kampioenen',
                    players: []
                },
                messages: []
            };

            const action = fromActions.getTeam({ id: 3 });
            const completion = fromActions.getTeamSuccess({ team: request.data });

            actions = hot('--a', { a: action });
            const response = cold('--b|', { b: request });
            const expected = cold('----c', { c: completion });
            service.getTeam = jest.fn(() => response);

            expect(effects.getTeam).toBeObservable(expected);
        });

        it('should return a getTeamFail, without data, on fail', () => {
            const action = fromActions.getTeam({ id: 3 });
            const completion = fromActions.getTeamFail();

            actions = hot('--a', { a: action });
            const response = cold('--#|');
            const expected = cold('----c', { c: completion });
            service.getTeam = jest.fn(() => response);

            expect(effects.getTeam).toBeObservable(expected);
        });
    });
});