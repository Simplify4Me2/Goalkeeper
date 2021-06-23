import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';

import * as fromStore from '../store';
import * as fromActions from '../store/home.actions';
import { HomeComponent } from '../containers/home.container';
import { MatchDayComponent, RankingComponent } from '../components';
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
                MatchDayComponent
            ],
            providers: [
                provideMockStore({
                    selectors: [{ selector: fromStore.selectLastMatchday, value: [] }, { selector: fromStore.selectRanking, value: [] },],
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

    it('should dispatch a getRankings on init', () => {
        const action = fromActions.getRanking();

        fixture.detectChanges();

        expect(store.dispatch).toHaveBeenCalledWith(action);
    });
});