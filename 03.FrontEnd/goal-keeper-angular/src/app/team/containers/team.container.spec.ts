import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

import * as fromActions from '../store/team.actions';
import { TeamContainerComponent } from '.';
// import { TeamComponent } from './team.container';
import { TeamInfoComponent } from '../components/team-info/team-info.component';
import { TeamPlayersComponent } from '../components/team-players/team-players.component';
import { selectTeam } from '../store';

describe('Team Container', () => {
    let fixture: ComponentFixture<TeamContainerComponent>;
    let instance: TeamContainerComponent;
    let store: MockStore;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [RouterTestingModule],
            declarations: [TeamContainerComponent, TeamInfoComponent, TeamPlayersComponent],
            providers: [
                {
                    provide: ActivatedRoute,
                    useValue: {
                        snapshot: {
                            paramMap: convertToParamMap({
                                id: '112'
                            })
                        }
                    }
                },
                provideMockStore()
            ]
        });

        fixture = TestBed.createComponent(TeamContainerComponent);
        instance = fixture.componentInstance;
        store = TestBed.inject(MockStore);

        spyOn(store, 'dispatch');
    });

    it('should compile', () => {
        fixture.detectChanges();

        expect(fixture).toMatchSnapshot();
    });

    it('should dispatch a getTeam on init', () => {
        const action = fromActions.getTeam({ id: 112 });

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });

    // it('should dispatch a getPlayers on init', () => {
    //     const action = getPlayers({ teamId: 112 });

    //     fixture.detectChanges();

    //     expect(store.dispatch).toHaveBeenLastCalledWith(action);
    // })
})