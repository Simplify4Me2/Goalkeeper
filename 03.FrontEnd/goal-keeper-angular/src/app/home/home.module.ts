import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './containers/home.container';
import * as fromHome from './store';
import { HomeEffects } from './store/home.effects';
import { RankingComponent } from './components/ranking/ranking.component';
import { NewsItemComponent } from './components/news-item/news-item.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [
        HomeComponent, RankingComponent, NewsItemComponent
    ],
    imports: [
        SharedModule,
        HomeRoutingModule,
        StoreModule.forFeature(fromHome.homeFeatureKey, fromHome.reducer),
        EffectsModule.forFeature([HomeEffects]),
    ],
})
export class HomeModule {}