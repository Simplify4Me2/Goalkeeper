import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { HomeRoutingModule } from './home-routing.module';
import { FixtureComponent } from './components/fixture/fixture.component';
import { HomeComponent } from './containers/home.component';
import * as fromHome from './store';
import { HomeEffects } from './store/home.effects';

@NgModule({
    declarations: [
        HomeComponent, FixtureComponent
    ],
    imports: [
        CommonModule,
        HomeRoutingModule,
        StoreModule.forFeature(fromHome.homeFeatureKey, fromHome.reducer),
        EffectsModule.forFeature([HomeEffects]),
    ],
})
export class HomeModule {}