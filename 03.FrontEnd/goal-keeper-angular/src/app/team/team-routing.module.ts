import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TeamContainerComponent, MatchesContainerComponent, SquadContainerComponent, StatsContainerComponent } from './containers';


const routes: Routes = [
    { 
        path: ':name', 
        component: TeamContainerComponent,
        children: [
            { path: 'fixtures', component: MatchesContainerComponent },
            { path: 'squad', component: SquadContainerComponent },
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