import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { TeamRoutingModule } from './team-routing.module';
import { SharedModule } from '../shared/shared.module';
import { TeamContainerComponent } from './containers/team.container';
import * as fromTeam from './store';
import { TeamCardsStatsComponent, TeamGoalsStatsComponent, TeamInfoComponent, TeamPlayersComponent } from './components';
import { TeamEffects } from './store/team.effects';
import { FixturesContainerComponent } from './containers/fixtures/fixtures.container';
import { SquadContainerComponent } from './containers/squad/squad.container';
import { StatsContainerComponent } from './containers/stats/stats.container';

@NgModule({
  declarations: [TeamContainerComponent, TeamInfoComponent, TeamPlayersComponent, FixturesContainerComponent, SquadContainerComponent, StatsContainerComponent, TeamGoalsStatsComponent, TeamCardsStatsComponent],
  imports: [
    SharedModule,
    TeamRoutingModule,
    StoreModule.forFeature(fromTeam.teamFeatureKey, fromTeam.reducer),
    EffectsModule.forFeature([TeamEffects])
  ]
})
export class TeamModule { }
