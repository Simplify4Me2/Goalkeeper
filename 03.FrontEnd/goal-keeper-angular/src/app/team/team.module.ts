import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { TeamRoutingModule } from './team-routing.module';
import { TeamComponent } from './containers/team.container';
import * as fromTeam from './store';
import { TeamEffects } from './store/team.effects';
import { TeamInfoComponent } from './components/team-info/team-info.component';
import { TeamPlayersComponent } from './components/team-players/team-players.component';

@NgModule({
  declarations: [TeamComponent, TeamInfoComponent, TeamPlayersComponent],
  imports: [
    CommonModule,
    TeamRoutingModule,
    StoreModule.forFeature(fromTeam.teamFeatureKey, fromTeam.reducer),
    EffectsModule.forFeature([TeamEffects])
  ]
})
export class TeamModule { }
