import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TeamContainerComponent, FixturesContainerComponent, PlayersContainerComponent, StatsContainerComponent } from './containers';


const routes: Routes = [
    { 
        path: ':id', 
        component: TeamContainerComponent,
        children: [
            { path: 'fixtures', component: FixturesContainerComponent },
            { path: 'squad', component: PlayersContainerComponent },
            { path: 'stats', component: StatsContainerComponent },
            { path: '', redirectTo: 'squad', pathMatch: 'full' },
            { path: '**', redirectTo: 'squad' },
          ],
     },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TeamRoutingModule {}