import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { getTeam } from '../store/team.actions';
import * as fromTeam from '../store';
import { Observable } from 'rxjs';
import { Team } from '../models/team.model';

@Component({
    selector: 'app-team',
    template: `<h1>Team container</h1>
                <app-team-info></app-team-info>`
})
export class TeamComponent implements OnInit {

    team: Observable<Team>;

    constructor(private store: Store) {}

    ngOnInit(): void {
        this.store.dispatch(getTeam());

        this.store.select(fromTeam.selectTeam);
    }

}