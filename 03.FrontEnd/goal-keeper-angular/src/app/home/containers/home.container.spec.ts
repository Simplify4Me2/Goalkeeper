import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';

import { selectFixtures, selectRanking } from '../store';
import { getMatches, getRanking } from '../store/home.actions';
import { HomeComponent } from '../containers/home.container';
import { MatchDayComponent, NewsItemComponent, RankingComponent } from '../components';
import { SharedModule } from '../../shared/shared.module';

describe('Home Container', () => {
    let fixture: ComponentFixture<HomeComponent>;
    let instance: HomeComponent;
    let store: MockStore;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                SharedModule,
                RouterTestingModule
            ],
            declarations: [
                HomeComponent,
                RankingComponent,
                NewsItemComponent,
                MatchDayComponent
            ],
            providers: [
                provideMockStore({
                    selectors: [{ selector: selectFixtures, value: [] }, { selector: selectRanking, value: [] },],
                }),
            ],
        });

        fixture = TestBed.createComponent(HomeComponent);
        instance = fixture.componentInstance;
        store = TestBed.inject(MockStore);

        spyOn(store, 'dispatch');
    });

    it('should compile', () => {
        fixture.detectChanges();

        expect(fixture).toMatchSnapshot();
    });

    it('should dispatch a getFixtures on init', () => {
        const action = getMatches();

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });

    it('should dispatch a getRankings on init', () => {
        const action = getRanking();

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });
});