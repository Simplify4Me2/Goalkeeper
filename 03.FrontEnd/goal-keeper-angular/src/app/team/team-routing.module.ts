import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TeamContainerComponent, FixturesContainerComponent, SquadContainerComponent, StatsContainerComponent } from './containers';


const routes: Routes = [
    { 
        path: ':name', 
        component: TeamContainerComponent,
        children: [
            { path: 'fixtures', component: FixturesContainerComponent },
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