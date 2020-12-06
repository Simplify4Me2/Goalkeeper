import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeamRoutingModule } from './team-routing.module';
import { TeamComponent } from './containers/team.container';

@NgModule({
  declarations: [TeamComponent],
  imports: [
    CommonModule,
    TeamRoutingModule
  ]
})
export class TeamModule { }
