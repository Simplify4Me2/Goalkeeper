import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';

import * as fromTeam from '../store';
import { Observable } from 'rxjs';
import { Team } from '../../team/models';

@Component({
    selector: 'app-team',
    template: ` <app-team-info [team]='team | async' ></app-team-info>
                <span>Fixtures | Squad | Stats</span>
                <app-team-players [players]='(team | async)?.players' ></app-team-players>`
})
export class TeamComponent implements OnInit {

    team: Observable<Team>;

    constructor(private store: Store, private route: ActivatedRoute) {}

    ngOnInit(): void {
        const id = Number(this.route.snapshot.paramMap.get('id'));

        this.store.dispatch(fromTeam.getTeam({ id: id }));

        this.team = this.store.select(fromTeam.selectTeam);
    }

}