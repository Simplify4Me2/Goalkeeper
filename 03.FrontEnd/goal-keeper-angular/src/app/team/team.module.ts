import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { TeamRoutingModule } from './team-routing.module';
import { SharedModule } from '../shared/shared.module';
import { TeamContainerComponent } from './containers/team.container';
import * as fromTeam from './store';
import { TeamCardsStatsComponent, TeamGoalsStatsComponent, TeamInfoComponent, TeamPlayersComponent } from './components';
import { TeamEffects } from './store/team.effects';
import { MatchesContainerComponent } from './containers/matches/matches.container';
import { SquadContainerComponent } from './containers/squad/squad.container';
import { StatsContainerComponent } from './containers/stats/stats.container';
import { TeamChartsComponent } from './components/team-charts/team-charts.component';
import { PlayerCardComponent } from './components/player-card/player-card.component';
import { FilterByPositionPipe } from './pipes/filter-by-position.pipe';

@NgModule({
  declarations: [TeamContainerComponent, TeamInfoComponent, TeamPlayersComponent, MatchesContainerComponent, SquadContainerComponent, StatsContainerComponent, TeamGoalsStatsComponent, TeamCardsStatsComponent, TeamChartsComponent, PlayerCardComponent, FilterByPositionPipe],
  imports: [
    SharedModule,
    TeamRoutingModule,
    StoreModule.forFeature(fromTeam.teamFeatureKey, fromTeam.reducer),
    EffectsModule.forFeature([TeamEffects])
  ]
})
export class TeamModule { }
