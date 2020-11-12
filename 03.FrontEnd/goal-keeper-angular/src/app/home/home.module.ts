import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';

import { HomeRoutingModule } from './home-routing.module';
import { FixtureComponent } from './components/fixture/fixture.component';
import { HomeComponent } from './containers/home.component';
import * as fromHome from './store';

@NgModule({
    declarations: [
        HomeComponent, FixtureComponent
    ],
    imports: [
        CommonModule,
        HomeRoutingModule,
        StoreModule.forFeature(fromHome.homeFeatureKey, fromHome.reducer),
    ],
})
export class HomeModule {}