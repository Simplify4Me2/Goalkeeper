import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { getTeam } from '../store/team.actions';
import * as fromTeam from '../store';
import { Observable } from 'rxjs';
import { Team } from '../../shared/models/team.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-team',
    template: `<h1>Team container</h1>
                <app-team-info [team]='team | async' ></app-team-info>`
})
export class TeamComponent implements OnInit {

    team: Observable<Team>;
    // team: Observable<string>;

    constructor(private store: Store, private route: ActivatedRoute) {}

    ngOnInit(): void {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        console.log(id);
        this.store.dispatch(getTeam({ id: id }));

        this.team = this.store.select(fromTeam.selectTeam);
    }

}