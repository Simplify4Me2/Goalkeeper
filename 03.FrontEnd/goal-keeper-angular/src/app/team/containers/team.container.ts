import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';

import * as fromTeam from '../store';
import { Observable } from 'rxjs';
import { Player, Team } from '../../team/models';

@Component({
    selector: 'app-team',
    template: `<h1>Team container</h1>
                <app-team-info [team]='team | async' ></app-team-info>
                <app-team-players [players]='players | async' ></app-team-players>`
})
export class TeamComponent implements OnInit {

    team: Observable<Team>;
    players: Observable<Player[]>;

    constructor(private store: Store, private route: ActivatedRoute) {}

    ngOnInit(): void {
        const id = Number(this.route.snapshot.paramMap.get('id'));

        this.store.dispatch(fromTeam.getTeam({ id: id }));
        this.store.dispatch(fromTeam.getPlayers({ teamId: id }));

        this.team = this.store.select(fromTeam.selectTeam);
        this.players = this.store.select(fromTeam.selectPlayers, { teamId: id });
    }

}