import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';

import { selectFixtures } from '../store';
import { getFixtures, getRankings } from '../store/home.actions';
import { HomeComponent } from '../containers/home.container';
import { FixtureComponent } from '../components/fixture/fixture.component';
import { RankingComponent } from '../components/ranking/ranking.component';
import { NewsItemComponent } from '../components/news-item/news-item.component';

describe('Home Page', () => {
    let fixture: ComponentFixture<HomeComponent>;
    let store: MockStore;
    let instance: HomeComponent;

    beforeEach(() => {

        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule
            ],
            declarations: [
                HomeComponent,
                FixtureComponent,
                RankingComponent,
                NewsItemComponent
            ],
            providers: [
                provideMockStore({
                    selectors: [{ selector: selectFixtures, value: [] }],
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
        const action = getFixtures();

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });

    it('should dispatch a getRankings on init', () => {
        const action = getRankings();

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });
});